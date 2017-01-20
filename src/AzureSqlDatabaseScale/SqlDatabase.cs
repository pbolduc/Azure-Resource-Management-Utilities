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
        private readonly Func<X509Certificate2> _getCertificate;

        public SqlDatabase(string subscriptionId, string serverName, string databaseName, string certificate, string password)
        {
            _subscriptionId = subscriptionId;
            _serverName = serverName;
            _databaseName = databaseName;

            _getCertificate = () => GetCertificate(certificate, password);
        }

        public SqlDatabase(string subscriptionId, string serverName, string databaseName, X509FindType findType, string certificate)
        {
            _subscriptionId = subscriptionId;
            _serverName = serverName;
            _databaseName = databaseName;
            _getCertificate = () => GetCertificate(findType, certificate);
        }

        public async Task<bool> ScaleUp(int levels = 1)
        {
            return await Scale(Higher, levels);
        }

        public async Task<bool> ScaleDown(int levels = 1)
        {
            return await Scale(Lower, levels);
        }

        public async Task<bool> ChangeServiceObjective(string newServiceObjectiveId)
        {
            var credentials = GetSubscriptionCloudCredentials(_subscriptionId);
            SqlManagementClient client = new SqlManagementClient(credentials);

            DatabaseGetResponse getDatabaseResponse = await client.Databases.GetAsync(_serverName, _databaseName);
            var database = getDatabaseResponse.Database;

            if (database.AssignedServiceObjectiveId != database.ServiceObjectiveId)
            {
                // service level change is already in progress
                return false;
            }

            if (newServiceObjectiveId == database.ServiceObjectiveId)
            {
                return false; // already at lowest service level
            }

            DatabaseUpdateParameters parameters = new DatabaseUpdateParameters();
            parameters.Name = database.Name;
            parameters.Edition = database.Edition;
            parameters.ServiceObjectiveId = newServiceObjectiveId;
            DatabaseUpdateResponse databaseUpdateResponse = await client.Databases.UpdateAsync(_serverName, _databaseName, parameters);

            return databaseUpdateResponse.StatusCode == HttpStatusCode.OK;
        }

        private async Task<bool> Scale(Func<string, string> change, int levels = 1)
        {
            var credentials = GetSubscriptionCloudCredentials(_subscriptionId);
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
                return false; // already at lowest service level
            }

            return await ChangeServiceObjective(newServiceObjectiveId);
        }

        private SubscriptionCloudCredentials GetSubscriptionCloudCredentials(string subscriptionId)
        {
            X509Certificate2 certificate = _getCertificate();
            SubscriptionCloudCredentials credentials = new CertificateCloudCredentials(subscriptionId, certificate);
            return credentials;
        }

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
                case ServiceObjectives.P3:
                    newServiceObjectiveId = ServiceObjectives.P2;
                    break;
            }
            return newServiceObjectiveId;
        }

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
                    newServiceObjectiveId = ServiceObjectives.P3;
                    break;

                case ServiceObjectives.P3:
                    break;
            }
            return newServiceObjectiveId;
        }

        private static X509Certificate2 GetCertificate(string base64Certificate, string password)
        {
            var certificateBytes = Convert.FromBase64String(base64Certificate);
            var certificate = new X509Certificate2(certificateBytes, password, X509KeyStorageFlags.MachineKeySet);
            return certificate;
        }

        private static X509Certificate2 GetCertificate(X509FindType findType, string certificateName)
        {
            // Initialize the Certificate Credential to be used by ADAL.
            X509Certificate2 certificate = null;
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                // Find unexpired certificates.
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                // From the collection of unexpired certificates, find the ones with the correct name.
                X509Certificate2Collection signingCert = currentCerts.Find(findType, certificateName, false);
                if (signingCert.Count != 0)
                {
                    // Return the first certificate in the collection, has the right name and is current.
                    certificate = signingCert[0];
                }
            }
            finally
            {
                store.Close();
            }

            return certificate;
        }
    }
}
