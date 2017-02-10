// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Details about app recovery operation.
    /// </summary>
    public partial class CsmSiteRecoveryEntity
    {
        /// <summary>
        /// Initializes a new instance of the CsmSiteRecoveryEntity class.
        /// </summary>
        public CsmSiteRecoveryEntity() { }

        /// <summary>
        /// Initializes a new instance of the CsmSiteRecoveryEntity class.
        /// </summary>
        /// <param name="snapshotTime">Point in time in which the app recovery
        /// should be attempted.</param>
        /// <param name="siteName">[Optional] Destination app name into which
        /// app should be recovered. This is case when new app should be
        /// created instead.</param>
        /// <param name="slotName">[Optional] Destination app slot name into
        /// which app should be recovered.</param>
        public CsmSiteRecoveryEntity(System.DateTime? snapshotTime = default(System.DateTime?), string siteName = default(string), string slotName = default(string))
        {
            SnapshotTime = snapshotTime;
            SiteName = siteName;
            SlotName = slotName;
        }

        /// <summary>
        /// Gets or sets point in time in which the app recovery should be
        /// attempted.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "snapshotTime")]
        public System.DateTime? SnapshotTime { get; set; }

        /// <summary>
        /// Gets or sets [Optional] Destination app name into which app should
        /// be recovered. This is case when new app should be created instead.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "siteName")]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets [Optional] Destination app slot name into which app
        /// should be recovered.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "slotName")]
        public string SlotName { get; set; }

    }
}
