// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Hybrid Connection for an App Service app.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class RelayServiceConnectionEntity : Resource
    {
        /// <summary>
        /// Initializes a new instance of the RelayServiceConnectionEntity
        /// class.
        /// </summary>
        public RelayServiceConnectionEntity() { }

        /// <summary>
        /// Initializes a new instance of the RelayServiceConnectionEntity
        /// class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        public RelayServiceConnectionEntity(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string entityName = default(string), string entityConnectionString = default(string), string resourceType = default(string), string resourceConnectionString = default(string), string hostname = default(string), int? port = default(int?), string biztalkUri = default(string))
            : base(location, id, name, kind, type, tags)
        {
            EntityName = entityName;
            EntityConnectionString = entityConnectionString;
            ResourceType = resourceType;
            ResourceConnectionString = resourceConnectionString;
            Hostname = hostname;
            Port = port;
            BiztalkUri = biztalkUri;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.entityName")]
        public string EntityName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.entityConnectionString")]
        public string EntityConnectionString { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.resourceConnectionString")]
        public string ResourceConnectionString { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.port")]
        public int? Port { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.biztalkUri")]
        public string BiztalkUri { get; set; }

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