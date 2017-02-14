namespace AzureScale.Authentication
{
    using System.Security.Cryptography.X509Certificates;

    public class CertificateLoginInformation
    {
        public CertificateLoginInformation()
        {            
        }

        public CertificateLoginInformation(string clientId, X509Certificate2 certificate)
        {
            ClientId = clientId;
            Certificate = certificate;
        }

        public string ClientId { get; set; }
        public X509Certificate2 Certificate { get; set; }
    }

    public class ServicePrincipalLoginInformation
    {
        public ServicePrincipalLoginInformation()
        {            
        }

        public ServicePrincipalLoginInformation(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }

}