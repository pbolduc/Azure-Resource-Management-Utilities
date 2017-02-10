// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Virtual IP mapping.
    /// </summary>
    public partial class VirtualIPMapping
    {
        /// <summary>
        /// Initializes a new instance of the VirtualIPMapping class.
        /// </summary>
        public VirtualIPMapping() { }

        /// <summary>
        /// Initializes a new instance of the VirtualIPMapping class.
        /// </summary>
        /// <param name="virtualIP">Virtual IP address.</param>
        /// <param name="internalHttpPort">Internal HTTP port.</param>
        /// <param name="internalHttpsPort">Internal HTTPS port.</param>
        /// <param name="inUse">Is virtual IP mapping in use.</param>
        public VirtualIPMapping(string virtualIP = default(string), int? internalHttpPort = default(int?), int? internalHttpsPort = default(int?), bool? inUse = default(bool?))
        {
            VirtualIP = virtualIP;
            InternalHttpPort = internalHttpPort;
            InternalHttpsPort = internalHttpsPort;
            InUse = inUse;
        }

        /// <summary>
        /// Gets or sets virtual IP address.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "virtualIP")]
        public string VirtualIP { get; set; }

        /// <summary>
        /// Gets or sets internal HTTP port.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "internalHttpPort")]
        public int? InternalHttpPort { get; set; }

        /// <summary>
        /// Gets or sets internal HTTPS port.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "internalHttpsPort")]
        public int? InternalHttpsPort { get; set; }

        /// <summary>
        /// Gets or sets is virtual IP mapping in use.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "inUse")]
        public bool? InUse { get; set; }

    }
}
