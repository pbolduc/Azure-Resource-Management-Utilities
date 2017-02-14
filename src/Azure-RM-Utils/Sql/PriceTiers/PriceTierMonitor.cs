namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.Azure.Management.Sql.Models;
    using ResourceManagement.Extensions.Sql;
    using ServiceObjective = ResourceManagement.Extensions.Sql.ServiceObjective;

    public class PriceTierMonitor
    {
        private TextWriter _log = TextWriter.Null;

        public PriceTierMonitor(TextWriter log = null)
        {
            if (log != null)
            {
                _log = log;
            }
        }
        
        public async Task UpdatePriceTier(
            SqlManagementClient client, 
            string resourceGroupName,
            string serverName,
            string databaseName,
            params DatabasePriceTierSetting[] settings)
        {
            if (settings.Length == 0)
            {
                settings = new [] { DatabasePriceTierSetting.Defaults() };
            }

            var sqlDatabase = await client.Databases.GetAsync(resourceGroupName, serverName, databaseName);

            if (!sqlDatabase.CurrentServiceObjectiveId.HasValue)
            {
                _log.WriteLine($"Database {databaseName} does not have a current service objective. Aborting.");
                return;
            }

            var currentServiceObjective = ServiceObjectives.Find(sqlDatabase.CurrentServiceObjectiveId.Value);

            if (sqlDatabase.RequestedServiceObjectiveId.HasValue && sqlDatabase.RequestedServiceObjectiveId != currentServiceObjective.Id)
            {
                // already being updated
                var requestedServiceObjective = ServiceObjectives.Find(sqlDatabase.RequestedServiceObjectiveId.Value);
                _log.WriteLine($"Database {databaseName} is already changing from {currentServiceObjective.Name} to {requestedServiceObjective.Name}.");
                return;
            }

            // if we recently changed price tier, avoid scaling again too quickly. get the changes to price tiers over the past 4 hours
            var history = await client.GetServiceObjectiveHistoryAsync(resourceGroupName, serverName, databaseName, TimeSpan.FromHours(4));

            var lastChange = history[history.Count - 1];
            var changed = DateTime.UtcNow - lastChange.Item1;

            foreach (var setting in settings)
            {
                ApplyDefaults(setting);

                //if (!IsActive(setting))
                //{
                //    continue;
                //}
                
                if (changed <= TimeSpan.FromMinutes(setting.MinChangeFrequency))
                {
                    _log.WriteLine($"Database {databaseName} changed {changed} ago which is less than the allowed change frequency {setting.MinChangeFrequency}.");
                    continue;
                }
                
                // determine the range of service objectives allowed
                var serviceObjectives = GetTargetServiceObjectives(sqlDatabase.Edition, setting).ToList();

                _log.WriteLine($"Database {databaseName} allowed tiers: {string.Join(", ", serviceObjectives.Select(_ => _.Name).ToArray())}.");

                // get the metrics on of the database
                var filter = GetMetricsFilter(setting);
                var response = await client.DatabaseExtensions().GetDatabaseResourceUsageMetricsAsync(resourceGroupName, serverName, databaseName, filter);

                // find the target metric - if none specified default to dtu_used
                var metric = "dtu_used";
                var dtuUsedValue = response.Values.Single(_ => _.Name.Value == metric);

                // determine the buffer room based on the metric, default to 100 (no buffer).
                // get the max: maximim/average/minimum dtu used over the history period
                var currentDtuLevel = dtuUsedValue.MetricValues.Max(GetMetricValueFunction(setting));
                var targetDtuLevel = currentDtuLevel * setting.Buffer / 100.0;

                _log.WriteLine($"Database {databaseName} target {metric} is {targetDtuLevel}. Current {setting.Value} DTU over past {setting.Period} minutes is {currentDtuLevel}.");

                // find the first service objective with at leat the target range.
                // TODO: need to handle dtu_consumption_percent
                ServiceObjective newServiceObjective = serviceObjectives.FirstOrDefault(_ => targetDtuLevel <= _.Dtu);

                if (newServiceObjective == null || newServiceObjective.Equals(currentServiceObjective))
                {
                    _log.WriteLine($"Database {databaseName} cannot be scaled past the current level ({currentServiceObjective.Name}).");
                    continue;
                }

                //_log.WriteLine($"Database {databaseName} has target metric of {target}. Current level {currentServiceObjective.Name}, target level {newServiceObjective.Name}");

                Database properties = new Database();
                properties.Location = sqlDatabase.Location;
                properties.Edition = newServiceObjective.Edition;
                properties.RequestedServiceObjectiveName = newServiceObjective.Name;

                await client.Databases.CreateOrUpdateAsync(resourceGroupName, serverName, databaseName, properties);
                break;
            }
        }


        private void ApplyDefaults(DatabasePriceTierSetting setting)
        {
            var defaults = DatabasePriceTierSetting.Defaults();

            if (setting.Buffer == 0)
            {
                setting.Buffer = defaults.Buffer;
            }

            if (setting.Period <= 0)
            {
                setting.Period = defaults.Period;
            }

            if (string.IsNullOrEmpty(setting.Value))
            {
                setting.Value = defaults.Value;
            }

            if (setting.MinChangeFrequency <= 0)
            {
                setting.MinChangeFrequency = defaults.MinChangeFrequency;
            }

            if (setting.Schedules == null)
            {
                setting.Schedules = Array.Empty<DatabasePriceTierSchedule>();
            }
        }

        /// <summary>
        /// Gets the metric value function that will be used to determine the DTU usage.
        /// </summary>
        private static Func<MetricValue, double> GetMetricValueFunction(DatabasePriceTierSetting parameters)
        {
            switch (parameters?.Value)
            {
                case "maximum":
                    return _ => _.Maximum;
                case "average":
                    return _ => _.Average;
                case "minimum":
                    return _ => _.Minimum;
            }

            return _ => _.Maximum;
        }

        private static DatabaseResourceUsageMetricsFilter GetMetricsFilter(DatabasePriceTierSetting parameters)
        {
            DateTime end = DateTime.UtcNow.RoundUp(TimeSpan.FromSeconds(15));
            DateTime start = end.AddHours(-1);
            var period = parameters?.Period;

            if (period.HasValue)
            {
                start = end.Subtract(TimeSpan.FromMinutes(period.Value));
            }

            DatabaseResourceUsageMetricsFilter filter = new DatabaseResourceUsageMetricsFilter(start, end, "dtu_used", "dtu_limit", "dtu_consumption_percent");

            return filter;
        }

        private static IEnumerable<ServiceObjective> GetTargetServiceObjectives(string edition, DatabasePriceTierSetting setting)
        {
            // no min or max tier specified, use the tiers based on the database engine
            if (string.IsNullOrEmpty(setting?.MinTier) && string.IsNullOrEmpty(setting?.MaxTier))
            {
                foreach (var serviceObjective in ServiceObjectives.All.Where(_ => _.Edition == edition))
                {
                    yield return serviceObjective;
                }

                yield break;
            }

            // get the minimum service objective
            ServiceObjective minServiceObjective = string.IsNullOrEmpty(setting?.MinTier)
                ? ServiceObjectives.All.First(_ => _.Edition == edition)
                : ServiceObjectives.All.First(_ => _.Name == setting.MinTier);

            // get the maximum service objective
            ServiceObjective maxServiceObjective = string.IsNullOrEmpty(setting?.MaxTier)
                ? ServiceObjectives.All.Last(_ => _.Edition == edition)
                : ServiceObjectives.All.First(_ => _.Name == setting.MaxTier);

            // return all the service objectives in the specified range
            bool yielding = false;

            foreach (ServiceObjective serviceObjective in ServiceObjectives.All)
            {
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
    }
}
