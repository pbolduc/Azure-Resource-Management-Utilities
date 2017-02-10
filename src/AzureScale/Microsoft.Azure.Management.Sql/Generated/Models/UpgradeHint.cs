// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Sql.Models
{
    using System.Linq;

    /// <summary>
    /// Represents a Upgrade Hint.
    /// </summary>
    public partial class UpgradeHint
    {
        /// <summary>
        /// Initializes a new instance of the UpgradeHint class.
        /// </summary>
        public UpgradeHint() { }

        /// <summary>
        /// Initializes a new instance of the UpgradeHint class.
        /// </summary>
        /// <param
        /// name="targetServiceLevelObjective">TargetServiceLevelObjective
        /// for upgrade hint.</param>
        /// <param
        /// name="targetServiceLevelObjectiveId">TargetServiceLevelObjectiveId
        /// for upgrade hint.</param>
        public UpgradeHint(string targetServiceLevelObjective = default(string), System.Guid? targetServiceLevelObjectiveId = default(System.Guid?))
        {
            TargetServiceLevelObjective = targetServiceLevelObjective;
            TargetServiceLevelObjectiveId = targetServiceLevelObjectiveId;
        }

        /// <summary>
        /// Gets or sets targetServiceLevelObjective for upgrade hint.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetServiceLevelObjective")]
        public string TargetServiceLevelObjective { get; set; }

        /// <summary>
        /// Gets or sets targetServiceLevelObjectiveId for upgrade hint.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetServiceLevelObjectiveId")]
        public System.Guid? TargetServiceLevelObjectiveId { get; set; }

    }
}
