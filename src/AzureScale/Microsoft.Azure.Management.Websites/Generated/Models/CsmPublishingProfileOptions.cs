// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Publishing options for requested profile.
    /// </summary>
    public partial class CsmPublishingProfileOptions
    {
        /// <summary>
        /// Initializes a new instance of the CsmPublishingProfileOptions
        /// class.
        /// </summary>
        public CsmPublishingProfileOptions() { }

        /// <summary>
        /// Initializes a new instance of the CsmPublishingProfileOptions
        /// class.
        /// </summary>
        /// <param name="format">Name of the format. Valid values are:
        /// FileZilla3
        /// WebDeploy -- default
        /// Ftp. Possible values include: 'FileZilla3', 'WebDeploy',
        /// 'Ftp'</param>
        public CsmPublishingProfileOptions(string format = default(string))
        {
            Format = format;
        }

        /// <summary>
        /// Gets or sets name of the format. Valid values are:
        /// FileZilla3
        /// WebDeploy -- default
        /// Ftp. Possible values include: 'FileZilla3', 'WebDeploy', 'Ftp'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

    }
}
