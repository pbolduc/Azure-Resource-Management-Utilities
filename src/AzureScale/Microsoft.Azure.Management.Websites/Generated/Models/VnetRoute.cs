// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Virtual Network route contract used to pass routing information for a
    /// Virtual Network.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class VnetRoute : Resource
    {
        /// <summary>
        /// Initializes a new instance of the VnetRoute class.
        /// </summary>
        public VnetRoute() { }

        /// <summary>
        /// Initializes a new instance of the VnetRoute class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="vnetRouteName">The name of this route. This is only
        /// returned by the server and does not need to be set by the
        /// client.</param>
        /// <param name="startAddress">The starting address for this route.
        /// This may also include a CIDR notation, in which case the end
        /// address must not be specified.</param>
        /// <param name="endAddress">The ending address for this route. If the
        /// start address is specified in CIDR notation, this must be
        /// omitted.</param>
        /// <param name="routeType">The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address
        /// ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// 
        /// These values will be used for syncing an app's routes with those
        /// from a Virtual Network. Possible values include: 'DEFAULT',
        /// 'INHERITED', 'STATIC'</param>
        public VnetRoute(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string vnetRouteName = default(string), string startAddress = default(string), string endAddress = default(string), string routeType = default(string))
            : base(location, id, name, kind, type, tags)
        {
            VnetRouteName = vnetRouteName;
            StartAddress = startAddress;
            EndAddress = endAddress;
            RouteType = routeType;
        }

        /// <summary>
        /// Gets or sets the name of this route. This is only returned by the
        /// server and does not need to be set by the client.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.name")]
        public string VnetRouteName { get; set; }

        /// <summary>
        /// Gets or sets the starting address for this route. This may also
        /// include a CIDR notation, in which case the end address must not
        /// be specified.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.startAddress")]
        public string StartAddress { get; set; }

        /// <summary>
        /// Gets or sets the ending address for this route. If the start
        /// address is specified in CIDR notation, this must be omitted.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.endAddress")]
        public string EndAddress { get; set; }

        /// <summary>
        /// Gets or sets the type of route this is:
        /// DEFAULT - By default, every app has routes to the local address
        /// ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// 
        /// These values will be used for syncing an app's routes with those
        /// from a Virtual Network. Possible values include: 'DEFAULT',
        /// 'INHERITED', 'STATIC'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.routeType")]
        public string RouteType { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
