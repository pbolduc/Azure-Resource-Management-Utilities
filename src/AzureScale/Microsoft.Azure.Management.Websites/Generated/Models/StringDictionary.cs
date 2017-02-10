// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// String dictionary resource.
    /// </summary>
    public partial class StringDictionary : Resource
    {
        /// <summary>
        /// Initializes a new instance of the StringDictionary class.
        /// </summary>
        public StringDictionary() { }

        /// <summary>
        /// Initializes a new instance of the StringDictionary class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="properties">Settings.</param>
        public StringDictionary(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> properties = default(System.Collections.Generic.IDictionary<string, string>))
            : base(location, id, name, kind, type, tags)
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets settings.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties")]
        public System.Collections.Generic.IDictionary<string, string> Properties { get; set; }

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
