// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Certificate order action.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class CertificateOrderAction : Resource
    {
        /// <summary>
        /// Initializes a new instance of the CertificateOrderAction class.
        /// </summary>
        public CertificateOrderAction() { }

        /// <summary>
        /// Initializes a new instance of the CertificateOrderAction class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="certificateOrderActionType">Action type. Possible
        /// values include: 'CertificateIssued', 'CertificateOrderCanceled',
        /// 'CertificateOrderCreated', 'CertificateRevoked',
        /// 'DomainValidationComplete', 'FraudDetected', 'OrgNameChange',
        /// 'OrgValidationComplete', 'SanDrop', 'FraudCleared',
        /// 'CertificateExpired', 'CertificateExpirationWarning',
        /// 'FraudDocumentationRequired', 'Unknown'</param>
        /// <param name="createdAt">Time at which the certificate action was
        /// performed.</param>
        public CertificateOrderAction(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), CertificateOrderActionType? certificateOrderActionType = default(CertificateOrderActionType?), System.DateTime? createdAt = default(System.DateTime?))
            : base(location, id, name, kind, type, tags)
        {
            CertificateOrderActionType = certificateOrderActionType;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Gets or sets action type. Possible values include:
        /// 'CertificateIssued', 'CertificateOrderCanceled',
        /// 'CertificateOrderCreated', 'CertificateRevoked',
        /// 'DomainValidationComplete', 'FraudDetected', 'OrgNameChange',
        /// 'OrgValidationComplete', 'SanDrop', 'FraudCleared',
        /// 'CertificateExpired', 'CertificateExpirationWarning',
        /// 'FraudDocumentationRequired', 'Unknown'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.type")]
        public CertificateOrderActionType? CertificateOrderActionType { get; set; }

        /// <summary>
        /// Gets or sets time at which the certificate action was performed.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.createdAt")]
        public System.DateTime? CreatedAt { get; set; }

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