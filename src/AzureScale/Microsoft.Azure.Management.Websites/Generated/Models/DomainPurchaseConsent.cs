// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Domain purchase consent object, representing acceptance of applicable
    /// legal agreements.
    /// </summary>
    public partial class DomainPurchaseConsent
    {
        /// <summary>
        /// Initializes a new instance of the DomainPurchaseConsent class.
        /// </summary>
        public DomainPurchaseConsent() { }

        /// <summary>
        /// Initializes a new instance of the DomainPurchaseConsent class.
        /// </summary>
        /// <param name="agreementKeys">List of applicable legal agreement
        /// keys. This list can be retrieved using ListLegalAgreements API
        /// under <code>TopLevelDomain</code> resource.</param>
        /// <param name="agreedBy">Client IP address.</param>
        /// <param name="agreedAt">Timestamp when the agreements were
        /// accepted.</param>
        public DomainPurchaseConsent(System.Collections.Generic.IList<string> agreementKeys = default(System.Collections.Generic.IList<string>), string agreedBy = default(string), System.DateTime? agreedAt = default(System.DateTime?))
        {
            AgreementKeys = agreementKeys;
            AgreedBy = agreedBy;
            AgreedAt = agreedAt;
        }

        /// <summary>
        /// Gets or sets list of applicable legal agreement keys. This list
        /// can be retrieved using ListLegalAgreements API under
        /// &lt;code&gt;TopLevelDomain&lt;/code&gt; resource.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "agreementKeys")]
        public System.Collections.Generic.IList<string> AgreementKeys { get; set; }

        /// <summary>
        /// Gets or sets client IP address.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "agreedBy")]
        public string AgreedBy { get; set; }

        /// <summary>
        /// Gets or sets timestamp when the agreements were accepted.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "agreedAt")]
        public System.DateTime? AgreedAt { get; set; }

    }
}
