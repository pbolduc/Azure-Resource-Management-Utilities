// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Error details for when validation fails.
    /// </summary>
    public partial class ValidateResponseError
    {
        /// <summary>
        /// Initializes a new instance of the ValidateResponseError class.
        /// </summary>
        public ValidateResponseError() { }

        /// <summary>
        /// Initializes a new instance of the ValidateResponseError class.
        /// </summary>
        /// <param name="code">Validation error code.</param>
        /// <param name="message">Validation error message.</param>
        public ValidateResponseError(string code = default(string), string message = default(string))
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets or sets validation error code.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets validation error message.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
