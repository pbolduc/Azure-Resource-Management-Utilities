namespace AzureScale
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    public static class Certificates
    {
        /// <summary>
        /// Gets the certificate from a base-64 encoded string.
        /// </summary>
        /// <param name="base64Certificate">The base-64 coded certificate.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static X509Certificate2 Load(string base64Certificate, string password)
        {
            var certificateBytes = Convert.FromBase64String(base64Certificate);
            var certificate = new X509Certificate2(certificateBytes, password, X509KeyStorageFlags.MachineKeySet);
            return certificate;
        }

        /// <summary>
        /// Gets the certificate from the current user's personal store.
        /// </summary>
        /// <param name="findType">The search type.</param>
        /// <param name="findValue">The search criteria as an object.</param>
        /// <returns></returns>
        public static X509Certificate2 Find(X509FindType findType, string findValue)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection validCertificates = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

                // From the collection of unexpired certificates, find the ones with the correct name.
                X509Certificate2Collection certificates = validCertificates.Find(findType, findValue, false);
                if (certificates.Count != 0)
                {
                    // Return the first certificate in the collection, has the right name and is current.
                    return certificates[0];
                }
            }
            finally
            {
                store.Close();
            }

            return null;
        }        
    }
}
