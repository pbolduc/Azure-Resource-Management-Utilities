// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{

    /// <summary>
    /// Defines values for CertificateProductType.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CertificateProductType
    {
        [System.Runtime.Serialization.EnumMember(Value = "StandardDomainValidatedSsl")]
        StandardDomainValidatedSsl,
        [System.Runtime.Serialization.EnumMember(Value = "StandardDomainValidatedWildCardSsl")]
        StandardDomainValidatedWildCardSsl
    }
}