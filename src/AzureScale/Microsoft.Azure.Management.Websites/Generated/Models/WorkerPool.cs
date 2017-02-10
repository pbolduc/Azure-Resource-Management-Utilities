// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Worker pool of an App Service Environment.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class WorkerPool : Resource
    {
        /// <summary>
        /// Initializes a new instance of the WorkerPool class.
        /// </summary>
        public WorkerPool() { }

        /// <summary>
        /// Initializes a new instance of the WorkerPool class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="workerSizeId">Worker size ID for referencing this
        /// worker pool.</param>
        /// <param name="computeMode">Shared or dedicated app hosting.
        /// Possible values include: 'Shared', 'Dedicated', 'Dynamic'</param>
        /// <param name="workerSize">VM size of the worker pool
        /// instances.</param>
        /// <param name="workerCount">Number of instances in the worker
        /// pool.</param>
        /// <param name="instanceNames">Names of all instances in the worker
        /// pool (read only).</param>
        public WorkerPool(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), int? workerSizeId = default(int?), ComputeModeOptions? computeMode = default(ComputeModeOptions?), string workerSize = default(string), int? workerCount = default(int?), System.Collections.Generic.IList<string> instanceNames = default(System.Collections.Generic.IList<string>), SkuDescription sku = default(SkuDescription))
            : base(location, id, name, kind, type, tags)
        {
            WorkerSizeId = workerSizeId;
            ComputeMode = computeMode;
            WorkerSize = workerSize;
            WorkerCount = workerCount;
            InstanceNames = instanceNames;
            Sku = sku;
        }

        /// <summary>
        /// Gets or sets worker size ID for referencing this worker pool.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.workerSizeId")]
        public int? WorkerSizeId { get; set; }

        /// <summary>
        /// Gets or sets shared or dedicated app hosting. Possible values
        /// include: 'Shared', 'Dedicated', 'Dynamic'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.computeMode")]
        public ComputeModeOptions? ComputeMode { get; set; }

        /// <summary>
        /// Gets or sets VM size of the worker pool instances.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.workerSize")]
        public string WorkerSize { get; set; }

        /// <summary>
        /// Gets or sets number of instances in the worker pool.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.workerCount")]
        public int? WorkerCount { get; set; }

        /// <summary>
        /// Gets names of all instances in the worker pool (read only).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.instanceNames")]
        public System.Collections.Generic.IList<string> InstanceNames { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sku")]
        public SkuDescription Sku { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
