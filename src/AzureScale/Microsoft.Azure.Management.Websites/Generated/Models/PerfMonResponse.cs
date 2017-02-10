// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Performance monitor API response.
    /// </summary>
    public partial class PerfMonResponse
    {
        /// <summary>
        /// Initializes a new instance of the PerfMonResponse class.
        /// </summary>
        public PerfMonResponse() { }

        /// <summary>
        /// Initializes a new instance of the PerfMonResponse class.
        /// </summary>
        /// <param name="code">The response code.</param>
        /// <param name="message">The message.</param>
        /// <param name="data">The performance monitor counters.</param>
        public PerfMonResponse(string code = default(string), string message = default(string), PerfMonSet data = default(PerfMonSet))
        {
            Code = code;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the performance monitor counters.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "data")]
        public PerfMonSet Data { get; set; }

    }
}
