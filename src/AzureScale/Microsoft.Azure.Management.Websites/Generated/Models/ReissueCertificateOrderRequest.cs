// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Class representing certificate reissue request.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class ReissueCertificateOrderRequest : Resource
    {
        /// <summary>
        /// Initializes a new instance of the ReissueCertificateOrderRequest
        /// class.
        /// </summary>
        public ReissueCertificateOrderRequest() { }

        /// <summary>
        /// Initializes a new instance of the ReissueCertificateOrderRequest
        /// class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="keySize">Certificate Key Size.</param>
        /// <param name="delayExistingRevokeInHours">Delay in hours to revoke
        /// existing certificate after the new certificate is issued.</param>
        /// <param name="csr">Csr to be used for re-key operation.</param>
        /// <param name="isPrivateKeyExternal">Should we change the ASC type
        /// (from managed private key to external private key and vice
        /// versa).</param>
        public ReissueCertificateOrderRequest(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), int? keySize = default(int?), int? delayExistingRevokeInHours = default(int?), string csr = default(string), bool? isPrivateKeyExternal = default(bool?))
            : base(location, id, name, kind, type, tags)
        {
            KeySize = keySize;
            DelayExistingRevokeInHours = delayExistingRevokeInHours;
            Csr = csr;
            IsPrivateKeyExternal = isPrivateKeyExternal;
        }

        /// <summary>
        /// Gets or sets certificate Key Size.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.keySize")]
        public int? KeySize { get; set; }

        /// <summary>
        /// Gets or sets delay in hours to revoke existing certificate after
        /// the new certificate is issued.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.delayExistingRevokeInHours")]
        public int? DelayExistingRevokeInHours { get; set; }

        /// <summary>
        /// Gets or sets csr to be used for re-key operation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.csr")]
        public string Csr { get; set; }

        /// <summary>
        /// Gets or sets should we change the ASC type (from managed private
        /// key to external private key and vice versa).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.isPrivateKeyExternal")]
        public bool? IsPrivateKeyExternal { get; set; }

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
