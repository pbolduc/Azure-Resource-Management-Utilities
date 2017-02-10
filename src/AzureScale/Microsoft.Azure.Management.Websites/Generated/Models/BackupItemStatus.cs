// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{

    /// <summary>
    /// Defines values for BackupItemStatus.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum BackupItemStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = "InProgress")]
        InProgress,
        [System.Runtime.Serialization.EnumMember(Value = "Failed")]
        Failed,
        [System.Runtime.Serialization.EnumMember(Value = "Succeeded")]
        Succeeded,
        [System.Runtime.Serialization.EnumMember(Value = "TimedOut")]
        TimedOut,
        [System.Runtime.Serialization.EnumMember(Value = "Created")]
        Created,
        [System.Runtime.Serialization.EnumMember(Value = "Skipped")]
        Skipped,
        [System.Runtime.Serialization.EnumMember(Value = "PartiallySucceeded")]
        PartiallySucceeded,
        [System.Runtime.Serialization.EnumMember(Value = "DeleteInProgress")]
        DeleteInProgress,
        [System.Runtime.Serialization.EnumMember(Value = "DeleteFailed")]
        DeleteFailed,
        [System.Runtime.Serialization.EnumMember(Value = "Deleted")]
        Deleted
    }
}
