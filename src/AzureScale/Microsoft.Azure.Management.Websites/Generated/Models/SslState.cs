// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{

    /// <summary>
    /// Defines values for SslState.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SslState
    {
        [System.Runtime.Serialization.EnumMember(Value = "Disabled")]
        Disabled,
        [System.Runtime.Serialization.EnumMember(Value = "SniEnabled")]
        SniEnabled,
        [System.Runtime.Serialization.EnumMember(Value = "IpBasedEnabled")]
        IpBasedEnabled
    }
}
