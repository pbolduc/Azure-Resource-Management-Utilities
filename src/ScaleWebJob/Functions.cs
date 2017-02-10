namespace ScaleWebJob
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using AzureScale;
    using AzureScale.Authentication;
    using AzureScale.Sql;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using ScaleWebJob.Configuration;
    using Database = Microsoft.Azure.Management.Sql.Models.Database;
    using Environment = ScaleWebJob.Configuration.Environment;
    using ServiceObjective = AzureScale.Sql.ServiceObjective;

    public static class Functions
    {
        public static async Task ScaleDatabases([TimerTrigger("0 */30 */1 * * *", RunOnStartup = true)]TimerInfo timer, TextWriter log)
        {
            log.WriteLine("Scaling Databases");

            var configFileName = ConfigurationManager.AppSettings["database-config-file"];
            if (string.IsNullOrEmpty(configFileName))
            {
                log.WriteLine($"Configuration setting 'database-config-file' not found. Please configure the location of your configuration file.");
                return;
            }

            if (!File.Exists(configFileName))
            {
                log.WriteLine($"Configuration file {configFileName} not found. Aborting.");
                return;
            }

            var environments = JsonConvert.DeserializeObject<Environment[]>(File.ReadAllText(configFileName));
            foreach (var environment in environments)
            {
                SqlManagementClient client = new SqlManagementClient(GetCredentials(environment.Authentication));
                client.SubscriptionId = environment.Authentication.SubscriptionId;

                foreach (var database in environment.Databases)
                {
                    var sqlDatabase = await client.Databases.GetAsync(database.ResourceGroup, database.Server, database.DatabaseName);

                    if (!sqlDatabase.CurrentServiceObjectiveId.HasValue)
                    {
                        log.WriteLine($"Database {database.DatabaseName} does not have a current service objective. Aborting.");
                        continue;
                    }

                    var currentServiceObjective = ServiceObjectives.Find(sqlDatabase.CurrentServiceObjectiveId.Value);

                    if (sqlDatabase.RequestedServiceObjectiveId.HasValue && sqlDatabase.RequestedServiceObjectiveId != currentServiceObjective.Id)
                    {
                        // already being updated
                        var requestedServiceObjective = ServiceObjectives.Find(sqlDatabase.RequestedServiceObjectiveId.Value);
                        log.WriteLine($"Database {database.DatabaseName} is already changing from {currentServiceObjective.Name} to {requestedServiceObjective.Name}.");
                        continue;
                    }

                    foreach (var setting in database.Settings)
                    {
                        if (!IsActive(setting))
                        {
                            continue;
                        }

                        // determine the range of service objectives allowed
                        var serviceObjectives = GetTargetServiceObjectives(sqlDatabase.Edition, setting).ToList();
                        
                        log.WriteLine($"Database {database.DatabaseName} allowed tiers: {string.Join(", ",serviceObjectives.Select(_ => _.Name).ToArray())}.");

                        // get the metrics on of the database
                        var filter = GetMetricsFilter(setting);
                        var response = await client.Databases.GetDatabaseResourceUsageMetricsAsync(database.ResourceGroup, database.Server, database.DatabaseName, filter);

                        // find the target metric - if none specified default to dtu_used
                        var metric = "dtu_used";
                        var dtuUsedValue = response.Values.Single(_ => _.Name.Value == "dtu_used");

                        // determine the buffer room based on the metric, default to 100 (no buffer).
                        var buffer = (double)(setting?.Buffer ?? 100);

                        // get the target metric value
                        var target = dtuUsedValue.MetricValues.Max(GetMetricValueFunction(setting)) * buffer / 100;

                        log.WriteLine($"Database {database.DatabaseName} target {metric} is {target}.");

                        // find the first service objective with at leat the target range.
                        // TODO: need to handle dtu_consumption_percent
                        ServiceObjective newServiceObjective = serviceObjectives.FirstOrDefault(_ => target <= _.Dtu);

                        if (newServiceObjective == null || newServiceObjective == currentServiceObjective)
                        {
                            log.WriteLine($"Database {database.DatabaseName} is cannot be scaled past the current level ({currentServiceObjective.Name}).");
                            continue;
                        }

                        log.WriteLine($"Database {database.DatabaseName} has target metric of {target}. Current level {currentServiceObjective.Name}, target level {newServiceObjective.Name}");

                        Database properties = new Database();
                        properties.Location = sqlDatabase.Location;
                        properties.Edition = newServiceObjective.Edition;
                        properties.RequestedServiceObjectiveName = newServiceObjective.Name;

                        await client.Databases.CreateOrUpdateAsync(database.ResourceGroup, database.Server, database.DatabaseName, properties);
                        break;
                    }
                }
            }
        }

        private static bool IsActive(DatabasePriceTierSetting setting)
        {
            return true;
        }

        private static Func<MetricValue, double> GetMetricValueFunction(DatabasePriceTierSetting parameters)
        {
            Func<MetricValue, double> valueFunc = Maximum;
            switch (parameters?.Value)
            {
                case "maximum":
                    valueFunc = Maximum;
                    break;
                case "average":
                    valueFunc = Average;
                    break;
            }

            return valueFunc;
        }

        private static DatabaseResourceUsageMetricsFilter GetMetricsFilter(DatabasePriceTierSetting parameters)
        {
            DateTime end = DateTime.UtcNow;
            DateTime start = end.AddHours(-1);
            var period = parameters?.Period;
            var grain = parameters?.Grain;

            TimeSpan timeSpan;
            if (!string.IsNullOrEmpty(period) && TimeSpan.TryParse(period, out timeSpan))
            {
                start = end.Subtract(timeSpan);
            }

            DatabaseResourceUsageMetricsFilter filter = new DatabaseResourceUsageMetricsFilter(start, end, "dtu_used", "dtu_limit", "dtu_consumption_percent");
            if (!string.IsNullOrEmpty(grain) && TimeSpan.TryParse(grain, out timeSpan))
            {
                filter.TimeGrain = timeSpan;
            }

            return filter;
        }

        private static double Maximum(MetricValue value) => value.Maximum;
        private static double Average(MetricValue value) => value.Average;

        private static IEnumerable<ServiceObjective> GetTargetServiceObjectives(string edition, DatabasePriceTierSetting setting)
        {
            if (string.IsNullOrEmpty(setting?.Minimum) && string.IsNullOrEmpty(setting?.Maximum))
            {
                foreach (var serviceObjective in ServiceObjectives.All.Where(_ => _.Edition == edition))
                {
                    yield return serviceObjective;
                }
            }

            ServiceObjective minServiceObjective;

            if (string.IsNullOrEmpty(setting?.Minimum))
            {
                minServiceObjective = ServiceObjectives.All.First(_ => _.Edition == edition);
            }
            else
            {
                minServiceObjective = ServiceObjectives.All.First(_ => _.Name == setting.Minimum);
            }

            ServiceObjective maxServiceObjective;
            if (string.IsNullOrEmpty(setting?.Maximum))
            {
                maxServiceObjective = ServiceObjectives.All.Last(_ => _.Edition == edition);
            }
            else
            {
                maxServiceObjective = ServiceObjectives.All.First(_ => _.Name == setting.Maximum);
            }

            bool yielding = false;

            for (int i = 0; i < ServiceObjectives.All.Count; i++)
            {
                ServiceObjective serviceObjective = ServiceObjectives.All[i];

                if (!yielding)
                {
                    if (serviceObjective.Id == minServiceObjective.Id)
                    {
                        yielding = true;
                    }
                }

                if (yielding)
                {
                    yield return serviceObjective;
                }

                if (serviceObjective.Id == maxServiceObjective.Id)
                {
                    yield break;
                }
            }
        }

        private static ServiceClientCredentials GetCredentials(Authentication authentication)
        {
            var clientId = authentication.ClientId;
            var tenant = authentication.Tenant;

            if (!string.IsNullOrEmpty(authentication.ClientSecret))
            {
                var clientSecret = authentication.ClientSecret;
                return new AzureCredentials(new ServicePrincipalLoginInformation(clientId, clientSecret), tenant);
            }

            if (authentication.Certificate.Find != null)
            {
                var find = authentication.Certificate.Find;
                X509FindType findType = (X509FindType)Enum.Parse(typeof(X509FindType), find.Type);

                var certificate = Certificates.Find(findType, find.Value);
                var credentials = new AzureCredentials(new CertificateLoginInformation(clientId, certificate), tenant);
                return credentials;
            }

            if (authentication.Certificate.Use != null)
            {
                var use = authentication.Certificate.Use;
                var encodedCertificate = Convert.ToBase64String(File.ReadAllBytes(use.Filename));
                var certificate = Certificates.Load(encodedCertificate, use.Password);
                var credentials = new AzureCredentials(new CertificateLoginInformation(clientId, certificate), tenant);
                return credentials;
            }

            throw new Exception("Unknow certificate source");
        }
    }


    namespace Configuration
    {
        using Newtonsoft.Json;

        public class Environment
        {
            [JsonProperty("authentication")]
            public Authentication Authentication { get; set; }
            [JsonProperty("databases")]
            public Database[] Databases { get; set; }
        }

        public class Authentication
        {
            [JsonProperty("subscriptionId")]
            public string SubscriptionId { get; set; }
            [JsonProperty("tenant")]
            public string Tenant { get; set; }
            [JsonProperty("clientId")]
            public string ClientId { get; set; }
            [JsonProperty("clientSecret")]
            public string ClientSecret { get; set; }
            [JsonProperty("certificate")]
            public Certificate Certificate { get; set; }
        }

        public class Certificate
        {
            [JsonProperty("find")]
            public CertificateFind Find { get; set; }
            [JsonProperty("use")]
            public CertificateUse Use { get; set; }
        }

        public class CertificateFind
        {
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        public class CertificateUse
        {
            [JsonProperty("filename")]
            public string Filename { get; set; }
            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public class Database
        {
            [JsonProperty("resourceGroup")]
            public string ResourceGroup { get; set; }
            [JsonProperty("server")]
            public string Server { get; set; }
            [JsonProperty("database")]
            public string DatabaseName { get; set; }

            [JsonProperty("settings")]
            public DatabasePriceTierSetting[] Settings { get; set; }
        }

        public class DatabasePriceTierSetting
        {
            [JsonProperty("period")]
            public string Period { get; set; }

            [JsonProperty("grain")]
            public string Grain { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("buffer")]
            public int? Buffer { get; set; }

            [JsonProperty("minTier")]
            public string Minimum { get; set; }

            [JsonProperty("maxTier")]
            public string Maximum { get; set; }

            [JsonProperty("schedules")]
            public DatabasePriceTierSchedule[] Schedules { get; set; }
        }

        public class DatabasePriceTierSchedule
        {
            [JsonProperty("begin")]
            public string Begin { get; set; }

            [JsonProperty("end")]
            public string End { get; set; }
        }

    }
}
