// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Sql.Models
{
    using System.Linq;

    /// <summary>
    /// Represents an Azure SQL server.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class Server : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Server class.
        /// </summary>
        public Server() { }

        /// <summary>
        /// Initializes a new instance of the Server class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="name">Resource name</param>
        /// <param name="id">Resource ID</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="fullyQualifiedDomainName">The fully qualified domain
        /// name of the server.</param>
        /// <param name="version">The version of the server. Possible values
        /// include: '2.0', '12.0'</param>
        /// <param name="administratorLogin">Administrator username for the
        /// server. Can only be specified when the server is being created
        /// (and is required for creation).</param>
        /// <param name="administratorLoginPassword">The administrator login
        /// password (required for server creation).</param>
        public Server(string location, string name = default(string), string id = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string fullyQualifiedDomainName = default(string), string version = default(string), string administratorLogin = default(string), string administratorLoginPassword = default(string))
            : base(location, name, id, type, tags)
        {
            FullyQualifiedDomainName = fullyQualifiedDomainName;
            Version = version;
            AdministratorLogin = administratorLogin;
            AdministratorLoginPassword = administratorLoginPassword;
        }

        /// <summary>
        /// Gets the fully qualified domain name of the server.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.fullyQualifiedDomainName")]
        public string FullyQualifiedDomainName { get; private set; }

        /// <summary>
        /// Gets or sets the version of the server. Possible values include:
        /// '2.0', '12.0'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets administrator username for the server. Can only be
        /// specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.administratorLogin")]
        public string AdministratorLogin { get; set; }

        /// <summary>
        /// Gets or sets the administrator login password (required for server
        /// creation).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.administratorLoginPassword")]
        public string AdministratorLoginPassword { get; set; }

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
