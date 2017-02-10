// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Stamp capacity information.
    /// </summary>
    public partial class StampCapacity
    {
        /// <summary>
        /// Initializes a new instance of the StampCapacity class.
        /// </summary>
        public StampCapacity() { }

        /// <summary>
        /// Initializes a new instance of the StampCapacity class.
        /// </summary>
        /// <param name="name">Name of the stamp.</param>
        /// <param name="availableCapacity">Available capacity (# of machines,
        /// bytes of storage etc...).</param>
        /// <param name="totalCapacity">Total capacity (# of machines, bytes
        /// of storage etc...).</param>
        /// <param name="unit">Name of the unit.</param>
        /// <param name="computeMode">Shared/dedicated workers. Possible
        /// values include: 'Shared', 'Dedicated', 'Dynamic'</param>
        /// <param name="workerSize">Size of the machines. Possible values
        /// include: 'Default', 'Small', 'Medium', 'Large'</param>
        /// <param name="workerSizeId">Size ID of machines:
        /// 0 - Small
        /// 1 - Medium
        /// 2 - Large</param>
        /// <param name="excludeFromCapacityAllocation">If <code>true</code>,
        /// it includes basic apps.
        /// Basic apps are not used for capacity allocation.</param>
        /// <param name="isApplicableForAllComputeModes"><code>true</code> if
        /// capacity is applicable for all apps; otherwise,
        /// <code>false</code>.</param>
        /// <param name="siteMode">Shared or Dedicated.</param>
        public StampCapacity(string name = default(string), long? availableCapacity = default(long?), long? totalCapacity = default(long?), string unit = default(string), ComputeModeOptions? computeMode = default(ComputeModeOptions?), WorkerSizeOptions? workerSize = default(WorkerSizeOptions?), int? workerSizeId = default(int?), bool? excludeFromCapacityAllocation = default(bool?), bool? isApplicableForAllComputeModes = default(bool?), string siteMode = default(string))
        {
            Name = name;
            AvailableCapacity = availableCapacity;
            TotalCapacity = totalCapacity;
            Unit = unit;
            ComputeMode = computeMode;
            WorkerSize = workerSize;
            WorkerSizeId = workerSizeId;
            ExcludeFromCapacityAllocation = excludeFromCapacityAllocation;
            IsApplicableForAllComputeModes = isApplicableForAllComputeModes;
            SiteMode = siteMode;
        }

        /// <summary>
        /// Gets or sets name of the stamp.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets available capacity (# of machines, bytes of storage
        /// etc...).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "availableCapacity")]
        public long? AvailableCapacity { get; set; }

        /// <summary>
        /// Gets or sets total capacity (# of machines, bytes of storage
        /// etc...).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCapacity")]
        public long? TotalCapacity { get; set; }

        /// <summary>
        /// Gets or sets name of the unit.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets shared/dedicated workers. Possible values include:
        /// 'Shared', 'Dedicated', 'Dynamic'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "computeMode")]
        public ComputeModeOptions? ComputeMode { get; set; }

        /// <summary>
        /// Gets or sets size of the machines. Possible values include:
        /// 'Default', 'Small', 'Medium', 'Large'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "workerSize")]
        public WorkerSizeOptions? WorkerSize { get; set; }

        /// <summary>
        /// Gets or sets size ID of machines:
        /// 0 - Small
        /// 1 - Medium
        /// 2 - Large
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "workerSizeId")]
        public int? WorkerSizeId { get; set; }

        /// <summary>
        /// Gets or sets if &lt;code&gt;true&lt;/code&gt;, it includes basic
        /// apps.
        /// Basic apps are not used for capacity allocation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "excludeFromCapacityAllocation")]
        public bool? ExcludeFromCapacityAllocation { get; set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; if capacity is
        /// applicable for all apps; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isApplicableForAllComputeModes")]
        public bool? IsApplicableForAllComputeModes { get; set; }

        /// <summary>
        /// Gets or sets shared or Dedicated.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "siteMode")]
        public string SiteMode { get; set; }

    }
}
