// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Sql.Models
{

    /// <summary>
    /// Defines values for RecommendedIndexTypes.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum RecommendedIndexTypes
    {
        [System.Runtime.Serialization.EnumMember(Value = "CLUSTERED")]
        CLUSTERED,
        [System.Runtime.Serialization.EnumMember(Value = "NONCLUSTERED")]
        NONCLUSTERED,
        [System.Runtime.Serialization.EnumMember(Value = "COLUMNSTORE")]
        COLUMNSTORE,
        [System.Runtime.Serialization.EnumMember(Value = "CLUSTERED COLUMNSTORE")]
        CLUSTEREDCOLUMNSTORE
    }
}
