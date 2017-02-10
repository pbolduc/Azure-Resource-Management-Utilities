// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// A deleted app.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class DeletedSite : Resource
    {
        /// <summary>
        /// Initializes a new instance of the DeletedSite class.
        /// </summary>
        public DeletedSite() { }

        /// <summary>
        /// Initializes a new instance of the DeletedSite class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="deletedTimestamp">Time in UTC when the app was
        /// deleted.</param>
        /// <param name="state">Current state of the app.</param>
        /// <param name="hostNames">Hostnames associated with the app.</param>
        /// <param name="repositorySiteName">Name of the repository
        /// site.</param>
        /// <param name="usageState">State indicating whether the app has
        /// exceeded its quota usage. Read-only. Possible values include:
        /// 'Normal', 'Exceeded'</param>
        /// <param name="enabled"><code>true</code> if the app is enabled;
        /// otherwise, <code>false</code>. Setting this value to false
        /// disables the app (takes the app offline).</param>
        /// <param name="enabledHostNames">Enabled hostnames for the
        /// app.Hostnames need to be assigned (see HostNames) AND enabled.
        /// Otherwise,
        /// the app is not served on those hostnames.</param>
        /// <param name="availabilityState">Management information
        /// availability state for the app. Possible values include:
        /// 'Normal', 'Limited', 'DisasterRecoveryMode'</param>
        /// <param name="hostNameSslStates">Hostname SSL states are used to
        /// manage the SSL bindings for app's hostnames.</param>
        /// <param name="serverFarmId">Resource ID of the associated App
        /// Service plan, formatted as:
        /// "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".</param>
        /// <param name="reserved"><code>true</code> if reserved; otherwise,
        /// <code>false</code>.</param>
        /// <param name="lastModifiedTimeUtc">Last time the app was modified,
        /// in UTC. Read-only.</param>
        /// <param name="siteConfig">Configuration of the app.</param>
        /// <param name="trafficManagerHostNames">Azure Traffic Manager
        /// hostnames associated with the app. Read-only.</param>
        /// <param name="premiumAppDeployed">Indicates whether app is deployed
        /// as a premium app.</param>
        /// <param name="scmSiteAlsoStopped"><code>true</code> to stop SCM
        /// (KUDU) site when the app is stopped; otherwise,
        /// <code>false</code>. The default is <code>false</code>.</param>
        /// <param name="targetSwapSlot">Specifies which deployment slot this
        /// app will swap into. Read-only.</param>
        /// <param name="hostingEnvironmentProfile">App Service Environment to
        /// use for the app.</param>
        /// <param name="microService">Micro services like apps, logic
        /// apps.</param>
        /// <param name="gatewaySiteName">Name of gateway app associated with
        /// the app.</param>
        /// <param name="clientAffinityEnabled"><code>true</code> to enable
        /// client affinity; <code>false</code> to stop sending session
        /// affinity cookies, which route client requests in the same session
        /// to the same instance. Default is <code>true</code>.</param>
        /// <param name="clientCertEnabled"><code>true</code> to enable client
        /// certificate authentication (TLS mutual authentication);
        /// otherwise, <code>false</code>. Default is
        /// <code>false</code>.</param>
        /// <param name="hostNamesDisabled"><code>true</code> to disable the
        /// public hostnames of the app; otherwise, <code>false</code>.
        /// If <code>true</code>, the app is only accessible via API
        /// management process.</param>
        /// <param name="outboundIpAddresses">List of IP addresses that the
        /// app uses for outbound connections (e.g. database access).
        /// Read-only.</param>
        /// <param name="containerSize">Size of the function container.</param>
        /// <param name="dailyMemoryTimeQuota">Maximum allowed daily
        /// memory-time quota (applicable on dynamic apps only).</param>
        /// <param name="suspendedTill">App suspended till in case memory-time
        /// quota is exceeded.</param>
        /// <param name="maxNumberOfWorkers">Maximum number of workers.
        /// This only applies to Functions container.</param>
        /// <param name="cloningInfo">If specified during app creation, the
        /// app is cloned from a source app.</param>
        /// <param name="resourceGroup">Name of the resource group the app
        /// belongs to. Read-only.</param>
        /// <param name="isDefaultContainer"><code>true</code> if the app is a
        /// default container; otherwise, <code>false</code>.</param>
        /// <param name="defaultHostName">Default hostname of the app.
        /// Read-only.</param>
        /// <param name="slotSwapStatus">Status of the last deployment slot
        /// swap operation.</param>
        public DeletedSite(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), System.DateTime? deletedTimestamp = default(System.DateTime?), string state = default(string), System.Collections.Generic.IList<string> hostNames = default(System.Collections.Generic.IList<string>), string repositorySiteName = default(string), UsageState? usageState = default(UsageState?), bool? enabled = default(bool?), System.Collections.Generic.IList<string> enabledHostNames = default(System.Collections.Generic.IList<string>), SiteAvailabilityState? availabilityState = default(SiteAvailabilityState?), System.Collections.Generic.IList<HostNameSslState> hostNameSslStates = default(System.Collections.Generic.IList<HostNameSslState>), string serverFarmId = default(string), bool? reserved = default(bool?), System.DateTime? lastModifiedTimeUtc = default(System.DateTime?), SiteConfig siteConfig = default(SiteConfig), System.Collections.Generic.IList<string> trafficManagerHostNames = default(System.Collections.Generic.IList<string>), bool? premiumAppDeployed = default(bool?), bool? scmSiteAlsoStopped = default(bool?), string targetSwapSlot = default(string), HostingEnvironmentProfile hostingEnvironmentProfile = default(HostingEnvironmentProfile), string microService = default(string), string gatewaySiteName = default(string), bool? clientAffinityEnabled = default(bool?), bool? clientCertEnabled = default(bool?), bool? hostNamesDisabled = default(bool?), string outboundIpAddresses = default(string), int? containerSize = default(int?), int? dailyMemoryTimeQuota = default(int?), System.DateTime? suspendedTill = default(System.DateTime?), int? maxNumberOfWorkers = default(int?), CloningInfo cloningInfo = default(CloningInfo), string resourceGroup = default(string), bool? isDefaultContainer = default(bool?), string defaultHostName = default(string), SlotSwapStatus slotSwapStatus = default(SlotSwapStatus))
            : base(location, id, name, kind, type, tags)
        {
            DeletedTimestamp = deletedTimestamp;
            State = state;
            HostNames = hostNames;
            RepositorySiteName = repositorySiteName;
            UsageState = usageState;
            Enabled = enabled;
            EnabledHostNames = enabledHostNames;
            AvailabilityState = availabilityState;
            HostNameSslStates = hostNameSslStates;
            ServerFarmId = serverFarmId;
            Reserved = reserved;
            LastModifiedTimeUtc = lastModifiedTimeUtc;
            SiteConfig = siteConfig;
            TrafficManagerHostNames = trafficManagerHostNames;
            PremiumAppDeployed = premiumAppDeployed;
            ScmSiteAlsoStopped = scmSiteAlsoStopped;
            TargetSwapSlot = targetSwapSlot;
            HostingEnvironmentProfile = hostingEnvironmentProfile;
            MicroService = microService;
            GatewaySiteName = gatewaySiteName;
            ClientAffinityEnabled = clientAffinityEnabled;
            ClientCertEnabled = clientCertEnabled;
            HostNamesDisabled = hostNamesDisabled;
            OutboundIpAddresses = outboundIpAddresses;
            ContainerSize = containerSize;
            DailyMemoryTimeQuota = dailyMemoryTimeQuota;
            SuspendedTill = suspendedTill;
            MaxNumberOfWorkers = maxNumberOfWorkers;
            CloningInfo = cloningInfo;
            ResourceGroup = resourceGroup;
            IsDefaultContainer = isDefaultContainer;
            DefaultHostName = defaultHostName;
            SlotSwapStatus = slotSwapStatus;
        }

        /// <summary>
        /// Gets time in UTC when the app was deleted.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.deletedTimestamp")]
        public System.DateTime? DeletedTimestamp { get; private set; }

        /// <summary>
        /// Gets current state of the app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.state")]
        public string State { get; private set; }

        /// <summary>
        /// Gets hostnames associated with the app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.hostNames")]
        public System.Collections.Generic.IList<string> HostNames { get; private set; }

        /// <summary>
        /// Gets name of the repository site.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.repositorySiteName")]
        public string RepositorySiteName { get; private set; }

        /// <summary>
        /// Gets state indicating whether the app has exceeded its quota
        /// usage. Read-only. Possible values include: 'Normal', 'Exceeded'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.usageState")]
        public UsageState? UsageState { get; private set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; if the app is enabled;
        /// otherwise, &lt;code&gt;false&lt;/code&gt;. Setting this value to
        /// false disables the app (takes the app offline).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets enabled hostnames for the app.Hostnames need to be assigned
        /// (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.enabledHostNames")]
        public System.Collections.Generic.IList<string> EnabledHostNames { get; private set; }

        /// <summary>
        /// Gets management information availability state for the app.
        /// Possible values include: 'Normal', 'Limited',
        /// 'DisasterRecoveryMode'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.availabilityState")]
        public SiteAvailabilityState? AvailabilityState { get; private set; }

        /// <summary>
        /// Gets or sets hostname SSL states are used to manage the SSL
        /// bindings for app's hostnames.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.hostNameSslStates")]
        public System.Collections.Generic.IList<HostNameSslState> HostNameSslStates { get; set; }

        /// <summary>
        /// Gets or sets resource ID of the associated App Service plan,
        /// formatted as:
        /// "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.serverFarmId")]
        public string ServerFarmId { get; set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; if reserved; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.reserved")]
        public bool? Reserved { get; set; }

        /// <summary>
        /// Gets last time the app was modified, in UTC. Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.lastModifiedTimeUtc")]
        public System.DateTime? LastModifiedTimeUtc { get; private set; }

        /// <summary>
        /// Gets or sets configuration of the app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.siteConfig")]
        public SiteConfig SiteConfig { get; set; }

        /// <summary>
        /// Gets azure Traffic Manager hostnames associated with the app.
        /// Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.trafficManagerHostNames")]
        public System.Collections.Generic.IList<string> TrafficManagerHostNames { get; private set; }

        /// <summary>
        /// Gets indicates whether app is deployed as a premium app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.premiumAppDeployed")]
        public bool? PremiumAppDeployed { get; private set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; to stop SCM (KUDU) site
        /// when the app is stopped; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;. The default is
        /// &lt;code&gt;false&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.scmSiteAlsoStopped")]
        public bool? ScmSiteAlsoStopped { get; set; }

        /// <summary>
        /// Gets specifies which deployment slot this app will swap into.
        /// Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.targetSwapSlot")]
        public string TargetSwapSlot { get; private set; }

        /// <summary>
        /// Gets or sets app Service Environment to use for the app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.hostingEnvironmentProfile")]
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        /// <summary>
        /// Gets or sets micro services like apps, logic apps.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.microService")]
        public string MicroService { get; set; }

        /// <summary>
        /// Gets or sets name of gateway app associated with the app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.gatewaySiteName")]
        public string GatewaySiteName { get; set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; to enable client
        /// affinity; &lt;code&gt;false&lt;/code&gt; to stop sending session
        /// affinity cookies, which route client requests in the same session
        /// to the same instance. Default is &lt;code&gt;true&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.clientAffinityEnabled")]
        public bool? ClientAffinityEnabled { get; set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; to enable client
        /// certificate authentication (TLS mutual authentication);
        /// otherwise, &lt;code&gt;false&lt;/code&gt;. Default is
        /// &lt;code&gt;false&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.clientCertEnabled")]
        public bool? ClientCertEnabled { get; set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; to disable the public
        /// hostnames of the app; otherwise, &lt;code&gt;false&lt;/code&gt;.
        /// If &lt;code&gt;true&lt;/code&gt;, the app is only accessible via
        /// API management process.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.hostNamesDisabled")]
        public bool? HostNamesDisabled { get; set; }

        /// <summary>
        /// Gets list of IP addresses that the app uses for outbound
        /// connections (e.g. database access). Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.outboundIpAddresses")]
        public string OutboundIpAddresses { get; private set; }

        /// <summary>
        /// Gets or sets size of the function container.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.containerSize")]
        public int? ContainerSize { get; set; }

        /// <summary>
        /// Gets or sets maximum allowed daily memory-time quota (applicable
        /// on dynamic apps only).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.dailyMemoryTimeQuota")]
        public int? DailyMemoryTimeQuota { get; set; }

        /// <summary>
        /// Gets app suspended till in case memory-time quota is exceeded.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.suspendedTill")]
        public System.DateTime? SuspendedTill { get; private set; }

        /// <summary>
        /// Gets maximum number of workers.
        /// This only applies to Functions container.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.maxNumberOfWorkers")]
        public int? MaxNumberOfWorkers { get; private set; }

        /// <summary>
        /// Gets or sets if specified during app creation, the app is cloned
        /// from a source app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.cloningInfo")]
        public CloningInfo CloningInfo { get; set; }

        /// <summary>
        /// Gets name of the resource group the app belongs to. Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.resourceGroup")]
        public string ResourceGroup { get; private set; }

        /// <summary>
        /// Gets &lt;code&gt;true&lt;/code&gt; if the app is a default
        /// container; otherwise, &lt;code&gt;false&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.isDefaultContainer")]
        public bool? IsDefaultContainer { get; private set; }

        /// <summary>
        /// Gets default hostname of the app. Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.defaultHostName")]
        public string DefaultHostName { get; private set; }

        /// <summary>
        /// Gets status of the last deployment slot swap operation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.slotSwapStatus")]
        public SlotSwapStatus SlotSwapStatus { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (this.SiteConfig != null)
            {
                this.SiteConfig.Validate();
            }
            if (this.CloningInfo != null)
            {
                this.CloningInfo.Validate();
            }
        }
    }
}
