namespace AzureSqlDatabaseScale
{
    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.Sql;
    using Microsoft.WindowsAzure.Management.Sql.Models;

    /// <summary>
    /// Provides wrapper around <see cref="SqlManagementClient"/> to scale up, 
    /// scale down or set the service level objective of an Azure SQL Database.
    /// Use to make it easier to 
    /// </summary>
    public class SqlDatabase
    {
        private readonly string _subscriptionId;
        private readonly string _serverName;
        private readonly string _databaseName;
        private readonly X509Certificate2 _certificate;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabase"/> class.
        /// </summary>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="serverName">Name of the database server.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="certificate">The certificate for authenticating to .</param>
        /// <exception cref="ArgumentNullException">
        /// subscriptionId
        /// or
        /// serverName
        /// or
        /// databaseName
        /// or
        /// certificate
        /// </exception>
        public SqlDatabase(string subscriptionId, string serverName, string databaseName, X509Certificate2 certificate)
        {
            if (subscriptionId == null) throw new ArgumentNullException(nameof(subscriptionId));
            if (serverName == null) throw new ArgumentNullException(nameof(serverName));
            if (databaseName == null) throw new ArgumentNullException(nameof(databaseName));
            if (certificate == null) throw new ArgumentNullException(nameof(certificate));

            _subscriptionId = subscriptionId;
            _serverName = serverName;
            _databaseName = databaseName;
            _certificate = certificate;
        }

        public async Task<HttpStatusCode> ScaleUp(int levels = 1)
        {
            return await Scale(Higher, levels);
        }

        public async Task<HttpStatusCode> ScaleDown(int levels = 1)
        {
            return await Scale(Lower, levels);
        }

        public async Task<HttpStatusCode> ChangeServiceObjective(string newServiceObjectiveId)
        {
            SubscriptionCloudCredentials credentials = new CertificateCloudCredentials(_subscriptionId, _certificate);
            SqlManagementClient client = new SqlManagementClient(credentials);

            DatabaseGetResponse getDatabaseResponse = await client.Databases.GetAsync(_serverName, _databaseName);
            var database = getDatabaseResponse.Database;

            if (database.AssignedServiceObjectiveId != database.ServiceObjectiveId)
            {
                // service level change is already in progress
                return HttpStatusCode.Conflict;
            }

            if (newServiceObjectiveId == database.ServiceObjectiveId)
            {
                return HttpStatusCode.OK; // already at lowest service level
            }

            DatabaseUpdateParameters parameters = new DatabaseUpdateParameters();
            parameters.Name = database.Name;
            parameters.Edition = database.Edition;
            parameters.ServiceObjectiveId = newServiceObjectiveId;
            DatabaseUpdateResponse databaseUpdateResponse = await client.Databases.UpdateAsync(_serverName, _databaseName, parameters);

            return databaseUpdateResponse.StatusCode;
        }

        private async Task<HttpStatusCode> Scale(Func<string, string> change, int levels = 1)
        {
            SubscriptionCloudCredentials credentials = new CertificateCloudCredentials(_subscriptionId, _certificate);
            SqlManagementClient client = new SqlManagementClient(credentials);

            DatabaseGetResponse getDatabaseResponse = await client.Databases.GetAsync(_serverName, _databaseName);
            var database = getDatabaseResponse.Database;

            var newServiceObjectiveId = database.ServiceObjectiveId;
            for (int i = 0; i < levels; i++)
            {
                newServiceObjectiveId = change(newServiceObjectiveId);
            }

            if (newServiceObjectiveId == database.ServiceObjectiveId)
            {
                return HttpStatusCode.OK; // already at lowest service level
            }

            return await ChangeServiceObjective(newServiceObjectiveId);
        }

        /// <summary>
        /// Get the next lower service objective.
        /// </summary>
        /// <param name="serviceObjectiveId">The current service objective.</param>
        /// <returns></returns>
        private static string Lower(string serviceObjectiveId)
        {
            string newServiceObjectiveId = serviceObjectiveId;
            switch (serviceObjectiveId)
            {
                case ServiceObjectives.Basic:
                    break;

                case ServiceObjectives.S0:
                    newServiceObjectiveId = ServiceObjectives.Basic;
                    break;
                case ServiceObjectives.S1:
                    newServiceObjectiveId = ServiceObjectives.S0;
                    break;
                case ServiceObjectives.S2:
                    newServiceObjectiveId = ServiceObjectives.S1;
                    break;
                case ServiceObjectives.S3:
                    newServiceObjectiveId = ServiceObjectives.S2;
                    break;

                case ServiceObjectives.P1:
                    break;
                case ServiceObjectives.P2:
                    newServiceObjectiveId = ServiceObjectives.P1;
                    break;
                case ServiceObjectives.P4:
                    newServiceObjectiveId = ServiceObjectives.P2;
                    break;
                case ServiceObjectives.P6:
                    newServiceObjectiveId = ServiceObjectives.P4;
                    break;
                case ServiceObjectives.P11:
                    newServiceObjectiveId = ServiceObjectives.P6;
                    break;
                case ServiceObjectives.P15:
                    newServiceObjectiveId = ServiceObjectives.P11;
                    break;
            }
            return newServiceObjectiveId;
        }

        /// <summary>
        /// Get the next higher service objective.
        /// </summary>
        /// <param name="serviceObjectiveId">The current service objective.</param>
        /// <returns></returns>
        private static string Higher(string serviceObjectiveId)
        {
            string newServiceObjectiveId = serviceObjectiveId;
            switch (serviceObjectiveId)
            {
                case ServiceObjectives.Basic:
                    newServiceObjectiveId = ServiceObjectives.S0;
                    break;

                case ServiceObjectives.S0:
                    newServiceObjectiveId = ServiceObjectives.S1;
                    break;
                case ServiceObjectives.S1:
                    newServiceObjectiveId = ServiceObjectives.S2;
                    break;
                case ServiceObjectives.S2:
                    newServiceObjectiveId = ServiceObjectives.S3;
                    break;
                case ServiceObjectives.S3:
                    break;

                case ServiceObjectives.P1:
                    newServiceObjectiveId = ServiceObjectives.P2;
                    break;
                case ServiceObjectives.P2:
                    newServiceObjectiveId = ServiceObjectives.P4;
                    break;
                case ServiceObjectives.P4:
                    newServiceObjectiveId = ServiceObjectives.P6;
                    break;
                case ServiceObjectives.P6:
                    newServiceObjectiveId = ServiceObjectives.P11;
                    break;
                case ServiceObjectives.P11:
                    newServiceObjectiveId = ServiceObjectives.P15;
                    break;
                case ServiceObjectives.P15:
                    break;
            }
            return newServiceObjectiveId;
        }
    }
}
