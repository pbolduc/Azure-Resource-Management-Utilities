namespace AzureScale.Sql
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using AzureScale.Authentication;
    using Microsoft.Azure.Management.Sql;

    /// <summary>
    /// Provides wrapper around <see cref="SqlManagementClient"/> to scale up, 
    /// scale down or set the service level objective of an Azure SQL Database.
    /// Use to make it easier to 
    /// </summary>
    public class SqlDatabaseClient
    {
        private readonly AzureCredentials _credentials; 

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabaseClient"/> class.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="certificate">The certificate for authenticating to .</param>
        /// <param name="tenant"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tenant"/> or <paramref name="clientId"/> or <paramref name="certificate"/> is null
        /// </exception>
        public SqlDatabaseClient(string tenant, string clientId, X509Certificate2 certificate)
        {
            if (tenant == null) throw new ArgumentNullException(nameof(tenant));
            if (clientId == null) throw new ArgumentNullException(nameof(clientId));
            if (certificate == null) throw new ArgumentNullException(nameof(certificate));

            _credentials = new AzureCredentials(new CertificateLoginInformation(clientId, certificate), tenant);
        }

        public async Task<HttpStatusCode> ChangeServiceObjectiveAsync(string resourceGroupName, string serverName, string databaseName, Guid newServiceObjectiveId)
        {
            if (newServiceObjectiveId == null) throw new ArgumentNullException(nameof(newServiceObjectiveId));

            SqlManagementClient client = new SqlManagementClient(_credentials);

            var database = await client.Databases.GetAsync(resourceGroupName, serverName, databaseName);

            if (database.RequestedServiceObjectiveId != database.CurrentServiceObjectiveId)
            {
                // service level change is already in progress
                return HttpStatusCode.Conflict;
            }

            if (newServiceObjectiveId == database.CurrentServiceObjectiveId || newServiceObjectiveId == database.RequestedServiceObjectiveId)
            {
                return HttpStatusCode.OK; // already at lowest service level
            }


            database.RequestedServiceObjectiveId = newServiceObjectiveId;
            var databaseUpdateResponse = await client.Databases.CreateOrUpdateAsync(resourceGroupName, serverName, databaseName, database);

            return HttpStatusCode.OK;
        }

        public async Task ScaleAsync(string subscriptionId, string resourceGroupName, string serverName, string databaseName, TimeSpan pastTime, double buffer = 1.0)
        {
            SqlManagementClient client = new SqlManagementClient(_credentials);
            client.SubscriptionId = subscriptionId;

            Guid serviceObjective = await GetTargetServiceObjective(client, resourceGroupName, serverName, databaseName, pastTime, buffer);

            var database = await client.Databases.GetAsync(resourceGroupName, serverName, databaseName);

            if (serviceObjective == database.CurrentServiceObjectiveId || serviceObjective == database.RequestedServiceObjectiveId)
            {
                Trace.WriteLine("Service Objective at target value.");
                return;
            }

            database.RequestedServiceObjectiveId = serviceObjective;
            database.Edition = DatabaseEdition(serviceObjective);

            Trace.WriteLine($"Updating Service Objective to: {serviceObjective}.");

            var updateResponse = await client.Databases.CreateOrUpdateAsync(resourceGroupName, serverName, databaseName, database);            
        }

        //public async Task<HttpStatusCode> ScaleDownAsync(string resourceGroupName, string serverName, string databaseName, int levels = 1)
        //{
        //    return await Scale(resourceGroupName, serverName, databaseName, Lower, levels);
        //}

        //public async Task<HttpStatusCode> ScaleUpAsync(string resourceGroupName, string serverName, string databaseName, int levels = 1)
        //{
        //    return await Scale(resourceGroupName, serverName, databaseName, Higher, levels);
        //}

        public async Task Scale(string subscriptionId, string resourceGroupName, string serverName, string databaseName, TimeSpan pastTime, double buffer = 1.0)
        {
            await ScaleAsync(subscriptionId, resourceGroupName, serverName, databaseName, pastTime, buffer);
        }

        private string DatabaseEdition(Guid serviceObjective)
        {
            if (serviceObjective == ServiceObjectives.Basic.Id) return "Basic";
            return "Standard";
        }

        private async Task<Guid> GetTargetServiceObjective(SqlManagementClient client, string resourceGroupName, string serverName, string databaseName, TimeSpan pastTime, double buffer = 0.0)
        {
            // get the amount of DTU used over the specified time frame
            var end = DateTime.UtcNow;
            var start = end.Subtract(pastTime);

            DatabaseResourceUsageMetricsFilter filter = new DatabaseResourceUsageMetricsFilter(start, end, "dtu_used", "storage");
            filter.TimeGrain = TimeSpan.FromMinutes(5);

            var response = await client.Databases.GetDatabaseResourceUsageMetricsAsync(resourceGroupName, serverName, databaseName, filter);

            var dtuUsage = response.Values.First(_ => _.Name.Value == "dtu_used");
            var maxDtuUsage = dtuUsage.MetricValues.Max(_ => Math.Min(100.0, _.Maximum * buffer));

            var storage = response.Values.First(_ => _.Name.Value == "storage");
            var databaseSize = storage.MetricValues.Max(_ => Math.Min(100.0, _.Maximum * buffer));

            if (100 <= maxDtuUsage)
            {
                return ServiceObjectives.S3.Id;
            }

            if (50 <= maxDtuUsage)
            {
                return ServiceObjectives.S2.Id;
            }

            if (20 <= maxDtuUsage)
            {
                return ServiceObjectives.S1.Id;
            }

            if (10 <= maxDtuUsage)
            {
                return ServiceObjectives.S0.Id;
            }

            return MinServiceObjective(databaseSize);
        }

        private Guid MinServiceObjective(double databaseSize)
        {
            // if less than 90% of the 2GB limit of basic, then use S0
            if ((1024.0 * 1024.0 * 1024.0 * 2 * 0.9) < databaseSize)
            {
                return ServiceObjectives.S0.Id;
            }

            return ServiceObjectives.Basic.Id;
        }

        private async Task<HttpStatusCode> Scale(string resourceGroupName, string serverName, string databaseName, Func<Guid, Guid> change, int levels = 1)
        {
            SqlManagementClient client = new SqlManagementClient(_credentials);

            var database = await client.Databases.GetAsync(resourceGroupName, serverName, databaseName);

            var newServiceObjectiveId = database.CurrentServiceObjectiveId.Value;
            for (int i = 0; i < levels; i++)
            {
                newServiceObjectiveId = change(newServiceObjectiveId);
            }

            if (newServiceObjectiveId == database.CurrentServiceObjectiveId || newServiceObjectiveId == database.RequestedServiceObjectiveId)
            {
                return HttpStatusCode.OK; // already at lowest service level or already requested to switch
            }

            return await ChangeServiceObjectiveAsync(resourceGroupName, serverName, databaseName, newServiceObjectiveId);
        }

    }

}
