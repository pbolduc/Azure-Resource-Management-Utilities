namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using AzureScale.Authentication;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Authentication;
    using Microsoft.Rest;
    using ServicePrincipalLoginInformation = Microsoft.Azure.Management.Resource.Fluent.Authentication.ServicePrincipalLoginInformation;

    public static class AuthenticationExtensions
    {
        public static ServiceClientCredentials GetCredentials(this Authentication source, AzureEnvironment environment = null)
        {
            if (environment == null)
            {
                environment = AzureEnvironment.AzureGlobalCloud;
            }

            var clientId = source.ClientId;
            var tenant = source.Tenant;

            if (!string.IsNullOrEmpty(source.ClientSecret))
            {
                //return AzureCredentialsFactory.From
                var clientSecret = source.ClientSecret;
                var login = new ServicePrincipalLoginInformation { ClientId = clientId, ClientSecret = clientSecret };
                return new AzureCredentials(login, tenant, environment);
            }

            if (source.Certificate != null)
            {
                if (source.Certificate.Find != null)
                {
                    var certificate = GetCertificate(source.Certificate.Find);
                    var credentials = new AzureCredentials(new CertificateLoginInformation(clientId, certificate), tenant, environment);
                    return credentials;
                }

                if (source.Certificate.Use != null)
                {
                    var certificate = GetCertificate(source.Certificate.Use);
                    var credentials = new AzureCredentials(new CertificateLoginInformation(clientId, certificate), tenant, environment);
                    return credentials;
                }
            }

            throw new Exception("Unknow certificate source");
        }

        private static X509Certificate2 GetCertificate(CertificateFind find)
        {
            X509FindType findType = (X509FindType)Enum.Parse(typeof(X509FindType), find.Type);

            X509Certificate2 certificate = Certificates.Find(findType, find.Value);
            return certificate;
        }

        private static X509Certificate2 GetCertificate(CertificateUse use)
        {
            var encodedCertificate = Convert.ToBase64String(File.ReadAllBytes(use.Filename));
            var certificate = Certificates.Load(encodedCertificate, use.Password);
            return certificate;
        }
    }
}