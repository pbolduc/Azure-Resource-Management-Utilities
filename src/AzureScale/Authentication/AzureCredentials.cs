namespace AzureScale.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;

    public class AzureCredentials : ServiceClientCredentials
    {
        private readonly IDictionary<Uri, ServiceClientCredentials> _credentialsCache;
        private readonly CertificateLoginInformation _certificateLoginInformation;
        private readonly ServicePrincipalLoginInformation _servicePrincipalLoginInformation;

        public AzureCredentials(ServicePrincipalLoginInformation servicePrincipalLoginInformation, string tenantId, AzureEnvironment environment = null)
             : this(tenantId, environment)
       {
            _servicePrincipalLoginInformation = servicePrincipalLoginInformation;
        }

        public AzureCredentials(CertificateLoginInformation certificateLoginInformation, string tenantId, AzureEnvironment environment = null)
            : this(tenantId, environment)
        {
            _certificateLoginInformation = certificateLoginInformation;
        }

        private AzureCredentials(string tenantId, AzureEnvironment environment = null)
        {
            TenantId = tenantId;
            Environment = environment ?? AzureEnvironment.AzureGlobalCloud;
            _credentialsCache = new Dictionary<Uri, ServiceClientCredentials>();
        }

        public string TenantId { get; private set; }
        public AzureEnvironment Environment { get; private set; }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(Environment.AuthenticationEndpoint),
                TokenAudience = new Uri(Environment.ResourceManagerEndpoint),
                ValidateAuthority = true
            };

            if (!_credentialsCache.ContainsKey(adSettings.TokenAudience))
            {
                var loginFunction = GetLoginFunction();
                _credentialsCache[adSettings.TokenAudience] = await loginFunction(adSettings);
            }

            await _credentialsCache[adSettings.TokenAudience].ProcessHttpRequestAsync(request, cancellationToken);
        }

        private Func<ActiveDirectoryServiceSettings, Task<ServiceClientCredentials>> GetLoginFunction()
        {
            if (_certificateLoginInformation != null)
            {
                return LoginWithCertificate;
            }

            // user login information (client id, username, password)

            // service principal login information (client id, client secret)
            if (_servicePrincipalLoginInformation != null)
            {
                return LoginWithApplicationToken;
            }

            throw new InvalidOperationException("Unknown login type.");
        }

        private async Task<ServiceClientCredentials> LoginWithApplicationToken(ActiveDirectoryServiceSettings settings)
        {
            var clientId = _servicePrincipalLoginInformation.ClientId;
            var clientSecret = _servicePrincipalLoginInformation.ClientSecret;

            var credentials = await ApplicationTokenProvider.LoginSilentAsync(TenantId, clientId, clientSecret, settings, TokenCache.DefaultShared);
            return credentials;
        }

        private async Task<ServiceClientCredentials> LoginWithCertificate(ActiveDirectoryServiceSettings settings)
        {
            var clientAssertion = new ClientAssertionCertificate(_certificateLoginInformation.ClientId, _certificateLoginInformation.Certificate);
            var credentials = await ApplicationTokenProvider.LoginSilentAsync(TenantId, clientAssertion, settings, TokenCache.DefaultShared);
            return credentials;
        }
    }
}