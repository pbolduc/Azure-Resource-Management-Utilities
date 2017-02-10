// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// A top level domain object.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class TopLevelDomain : Resource
    {
        /// <summary>
        /// Initializes a new instance of the TopLevelDomain class.
        /// </summary>
        public TopLevelDomain() { }

        /// <summary>
        /// Initializes a new instance of the TopLevelDomain class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="domainName">Name of the top level domain.</param>
        /// <param name="privacy">If <code>true</code>, then the top level
        /// domain supports domain privacy; otherwise,
        /// <code>false</code>.</param>
        public TopLevelDomain(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string domainName = default(string), bool? privacy = default(bool?))
            : base(location, id, name, kind, type, tags)
        {
            DomainName = domainName;
            Privacy = privacy;
        }

        /// <summary>
        /// Gets name of the top level domain.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.name")]
        public string DomainName { get; private set; }

        /// <summary>
        /// Gets or sets if &lt;code&gt;true&lt;/code&gt;, then the top level
        /// domain supports domain privacy; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.privacy")]
        public bool? Privacy { get; set; }

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