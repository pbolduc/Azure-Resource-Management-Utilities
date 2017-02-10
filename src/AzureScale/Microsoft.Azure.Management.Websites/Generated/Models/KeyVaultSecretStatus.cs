// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{

    /// <summary>
    /// Defines values for KeyVaultSecretStatus.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum KeyVaultSecretStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = "Initialized")]
        Initialized,
        [System.Runtime.Serialization.EnumMember(Value = "WaitingOnCertificateOrder")]
        WaitingOnCertificateOrder,
        [System.Runtime.Serialization.EnumMember(Value = "Succeeded")]
        Succeeded,
        [System.Runtime.Serialization.EnumMember(Value = "CertificateOrderFailed")]
        CertificateOrderFailed,
        [System.Runtime.Serialization.EnumMember(Value = "OperationNotPermittedOnKeyVault")]
        OperationNotPermittedOnKeyVault,
        [System.Runtime.Serialization.EnumMember(Value = "AzureServiceUnauthorizedToAccessKeyVault")]
        AzureServiceUnauthorizedToAccessKeyVault,
        [System.Runtime.Serialization.EnumMember(Value = "KeyVaultDoesNotExist")]
        KeyVaultDoesNotExist,
        [System.Runtime.Serialization.EnumMember(Value = "KeyVaultSecretDoesNotExist")]
        KeyVaultSecretDoesNotExist,
        [System.Runtime.Serialization.EnumMember(Value = "UnknownError")]
        UnknownError,
        [System.Runtime.Serialization.EnumMember(Value = "ExternalPrivateKey")]
        ExternalPrivateKey,
        [System.Runtime.Serialization.EnumMember(Value = "Unknown")]
        Unknown
    }
}
