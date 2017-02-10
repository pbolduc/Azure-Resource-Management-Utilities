// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Metric limits set on an app.
    /// </summary>
    public partial class SiteLimits
    {
        /// <summary>
        /// Initializes a new instance of the SiteLimits class.
        /// </summary>
        public SiteLimits() { }

        /// <summary>
        /// Initializes a new instance of the SiteLimits class.
        /// </summary>
        /// <param name="maxPercentageCpu">Maximum allowed CPU usage
        /// percentage.</param>
        /// <param name="maxMemoryInMb">Maximum allowed memory usage in
        /// MB.</param>
        /// <param name="maxDiskSizeInMb">Maximum allowed disk size usage in
        /// MB.</param>
        public SiteLimits(double? maxPercentageCpu = default(double?), long? maxMemoryInMb = default(long?), long? maxDiskSizeInMb = default(long?))
        {
            MaxPercentageCpu = maxPercentageCpu;
            MaxMemoryInMb = maxMemoryInMb;
            MaxDiskSizeInMb = maxDiskSizeInMb;
        }

        /// <summary>
        /// Gets or sets maximum allowed CPU usage percentage.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxPercentageCpu")]
        public double? MaxPercentageCpu { get; set; }

        /// <summary>
        /// Gets or sets maximum allowed memory usage in MB.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxMemoryInMb")]
        public long? MaxMemoryInMb { get; set; }

        /// <summary>
        /// Gets or sets maximum allowed disk size usage in MB.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxDiskSizeInMb")]
        public long? MaxDiskSizeInMb { get; set; }

    }
}