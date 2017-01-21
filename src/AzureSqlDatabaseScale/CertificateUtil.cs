namespace AzureSqlDatabaseScale
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    public static class CertificateUtil
    {
        public static X509Certificate2 GetCertificate(string base64Certificate, string password)
        {
            var certificateBytes = Convert.FromBase64String(base64Certificate);
            var certificate = new X509Certificate2(certificateBytes, password, X509KeyStorageFlags.MachineKeySet);
            return certificate;
        }

        public static X509Certificate2 GetCertificate(X509FindType findType, string findValue)
        {
            X509Certificate2 certificate = null;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            try
            {
                store.Open(OpenFlags.ReadOnly);
                // Find unexpired certificates.
                X509Certificate2Collection currentCertificates = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

                // From the collection of unexpired certificates, find the ones with the correct name.
                X509Certificate2Collection certificates = currentCertificates.Find(findType, findValue, false);
                if (certificates.Count != 0)
                {
                    // Return the first certificate in the collection, has the right name and is current.
                    certificate = certificates[0];
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