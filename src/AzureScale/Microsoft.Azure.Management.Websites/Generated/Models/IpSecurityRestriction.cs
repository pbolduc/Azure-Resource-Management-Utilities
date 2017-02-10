// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// IP security restriction on an app.
    /// </summary>
    public partial class IpSecurityRestriction
    {
        /// <summary>
        /// Initializes a new instance of the IpSecurityRestriction class.
        /// </summary>
        public IpSecurityRestriction() { }

        /// <summary>
        /// Initializes a new instance of the IpSecurityRestriction class.
        /// </summary>
        /// <param name="ipAddress">IP address the security restriction is
        /// valid for.</param>
        /// <param name="subnetMask">Subnet mask for the range of IP addresses
        /// the restriction is valid for.</param>
        public IpSecurityRestriction(string ipAddress, string subnetMask = default(string))
        {
            IpAddress = ipAddress;
            SubnetMask = subnetMask;
        }

        /// <summary>
        /// Gets or sets IP address the security restriction is valid for.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets subnet mask for the range of IP addresses the
        /// restriction is valid for.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "subnetMask")]
        public string SubnetMask { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (IpAddress == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "IpAddress");
            }
        }
    }
}
