// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Sql.Models
{
    using System.Linq;

    /// <summary>
    /// Represents a Service Tier Advisor.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class ServiceTierAdvisor : SqlSubResource
    {
        /// <summary>
        /// Initializes a new instance of the ServiceTierAdvisor class.
        /// </summary>
        public ServiceTierAdvisor() { }

        /// <summary>
        /// Initializes a new instance of the ServiceTierAdvisor class.
        /// </summary>
        /// <param name="name">Resource name</param>
        /// <param name="id">The resource ID.</param>
        /// <param name="observationPeriodStart">The observation period start
        /// (ISO8601 format).</param>
        /// <param name="observationPeriodEnd">The observation period start
        /// (ISO8601 format).</param>
        /// <param name="activeTimeRatio">The activeTimeRatio for service tier
        /// advisor.</param>
        /// <param name="minDtu">Gets or sets minDtu for service tier
        /// advisor.</param>
        /// <param name="avgDtu">Gets or sets avgDtu for service tier
        /// advisor.</param>
        /// <param name="maxDtu">Gets or sets maxDtu for service tier
        /// advisor.</param>
        /// <param name="maxSizeInGB">Gets or sets maxSizeInGB for service
        /// tier advisor.</param>
        /// <param name="serviceLevelObjectiveUsageMetrics">Gets or sets
        /// serviceLevelObjectiveUsageMetrics for the service tier
        /// advisor.</param>
        /// <param name="currentServiceLevelObjective">Gets or sets
        /// currentServiceLevelObjective for service tier advisor.</param>
        /// <param name="currentServiceLevelObjectiveId">Gets or sets
        /// currentServiceLevelObjectiveId for service tier advisor.</param>
        /// <param name="usageBasedRecommendationServiceLevelObjective">Gets
        /// or sets usageBasedRecommendationServiceLevelObjective for service
        /// tier advisor.</param>
        /// <param name="usageBasedRecommendationServiceLevelObjectiveId">Gets
        /// or sets usageBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.</param>
        /// <param
        /// name="databaseSizeBasedRecommendationServiceLevelObjective">Gets
        /// or sets databaseSizeBasedRecommendationServiceLevelObjective for
        /// service tier advisor.</param>
        /// <param
        /// name="databaseSizeBasedRecommendationServiceLevelObjectiveId">Gets
        /// or sets databaseSizeBasedRecommendationServiceLevelObjectiveId
        /// for service tier advisor.</param>
        /// <param
        /// name="disasterPlanBasedRecommendationServiceLevelObjective">Gets
        /// or sets disasterPlanBasedRecommendationServiceLevelObjective for
        /// service tier advisor.</param>
        /// <param
        /// name="disasterPlanBasedRecommendationServiceLevelObjectiveId">Gets
        /// or sets disasterPlanBasedRecommendationServiceLevelObjectiveId
        /// for service tier advisor.</param>
        /// <param name="overallRecommendationServiceLevelObjective">Gets or
        /// sets overallRecommendationServiceLevelObjective for service tier
        /// advisor.</param>
        /// <param name="overallRecommendationServiceLevelObjectiveId">Gets or
        /// sets overallRecommendationServiceLevelObjectiveId for service
        /// tier advisor.</param>
        /// <param name="confidence">Gets or sets confidence for service tier
        /// advisor.</param>
        public ServiceTierAdvisor(string name = default(string), string id = default(string), System.DateTime? observationPeriodStart = default(System.DateTime?), System.DateTime? observationPeriodEnd = default(System.DateTime?), double? activeTimeRatio = default(double?), double? minDtu = default(double?), double? avgDtu = default(double?), double? maxDtu = default(double?), double? maxSizeInGB = default(double?), System.Collections.Generic.IList<SloUsageMetric> serviceLevelObjectiveUsageMetrics = default(System.Collections.Generic.IList<SloUsageMetric>), string currentServiceLevelObjective = default(string), System.Guid? currentServiceLevelObjectiveId = default(System.Guid?), string usageBasedRecommendationServiceLevelObjective = default(string), System.Guid? usageBasedRecommendationServiceLevelObjectiveId = default(System.Guid?), string databaseSizeBasedRecommendationServiceLevelObjective = default(string), System.Guid? databaseSizeBasedRecommendationServiceLevelObjectiveId = default(System.Guid?), string disasterPlanBasedRecommendationServiceLevelObjective = default(string), System.Guid? disasterPlanBasedRecommendationServiceLevelObjectiveId = default(System.Guid?), string overallRecommendationServiceLevelObjective = default(string), System.Guid? overallRecommendationServiceLevelObjectiveId = default(System.Guid?), double? confidence = default(double?))
            : base(name, id)
        {
            ObservationPeriodStart = observationPeriodStart;
            ObservationPeriodEnd = observationPeriodEnd;
            ActiveTimeRatio = activeTimeRatio;
            MinDtu = minDtu;
            AvgDtu = avgDtu;
            MaxDtu = maxDtu;
            MaxSizeInGB = maxSizeInGB;
            ServiceLevelObjectiveUsageMetrics = serviceLevelObjectiveUsageMetrics;
            CurrentServiceLevelObjective = currentServiceLevelObjective;
            CurrentServiceLevelObjectiveId = currentServiceLevelObjectiveId;
            UsageBasedRecommendationServiceLevelObjective = usageBasedRecommendationServiceLevelObjective;
            UsageBasedRecommendationServiceLevelObjectiveId = usageBasedRecommendationServiceLevelObjectiveId;
            DatabaseSizeBasedRecommendationServiceLevelObjective = databaseSizeBasedRecommendationServiceLevelObjective;
            DatabaseSizeBasedRecommendationServiceLevelObjectiveId = databaseSizeBasedRecommendationServiceLevelObjectiveId;
            DisasterPlanBasedRecommendationServiceLevelObjective = disasterPlanBasedRecommendationServiceLevelObjective;
            DisasterPlanBasedRecommendationServiceLevelObjectiveId = disasterPlanBasedRecommendationServiceLevelObjectiveId;
            OverallRecommendationServiceLevelObjective = overallRecommendationServiceLevelObjective;
            OverallRecommendationServiceLevelObjectiveId = overallRecommendationServiceLevelObjectiveId;
            Confidence = confidence;
        }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.observationPeriodStart")]
        public System.DateTime? ObservationPeriodStart { get; private set; }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.observationPeriodEnd")]
        public System.DateTime? ObservationPeriodEnd { get; private set; }

        /// <summary>
        /// Gets the activeTimeRatio for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.activeTimeRatio")]
        public double? ActiveTimeRatio { get; private set; }

        /// <summary>
        /// Gets or sets minDtu for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.minDtu")]
        public double? MinDtu { get; private set; }

        /// <summary>
        /// Gets or sets avgDtu for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.avgDtu")]
        public double? AvgDtu { get; private set; }

        /// <summary>
        /// Gets or sets maxDtu for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.maxDtu")]
        public double? MaxDtu { get; private set; }

        /// <summary>
        /// Gets or sets maxSizeInGB for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.maxSizeInGB")]
        public double? MaxSizeInGB { get; private set; }

        /// <summary>
        /// Gets or sets serviceLevelObjectiveUsageMetrics for the service
        /// tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.serviceLevelObjectiveUsageMetrics")]
        public System.Collections.Generic.IList<SloUsageMetric> ServiceLevelObjectiveUsageMetrics { get; private set; }

        /// <summary>
        /// Gets or sets currentServiceLevelObjective for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.currentServiceLevelObjective")]
        public string CurrentServiceLevelObjective { get; private set; }

        /// <summary>
        /// Gets or sets currentServiceLevelObjectiveId for service tier
        /// advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.currentServiceLevelObjectiveId")]
        public System.Guid? CurrentServiceLevelObjectiveId { get; private set; }

        /// <summary>
        /// Gets or sets usageBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.usageBasedRecommendationServiceLevelObjective")]
        public string UsageBasedRecommendationServiceLevelObjective { get; private set; }

        /// <summary>
        /// Gets or sets usageBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.usageBasedRecommendationServiceLevelObjectiveId")]
        public System.Guid? UsageBasedRecommendationServiceLevelObjectiveId { get; private set; }

        /// <summary>
        /// Gets or sets databaseSizeBasedRecommendationServiceLevelObjective
        /// for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.databaseSizeBasedRecommendationServiceLevelObjective")]
        public string DatabaseSizeBasedRecommendationServiceLevelObjective { get; private set; }

        /// <summary>
        /// Gets or sets
        /// databaseSizeBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.databaseSizeBasedRecommendationServiceLevelObjectiveId")]
        public System.Guid? DatabaseSizeBasedRecommendationServiceLevelObjectiveId { get; private set; }

        /// <summary>
        /// Gets or sets disasterPlanBasedRecommendationServiceLevelObjective
        /// for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.disasterPlanBasedRecommendationServiceLevelObjective")]
        public string DisasterPlanBasedRecommendationServiceLevelObjective { get; private set; }

        /// <summary>
        /// Gets or sets
        /// disasterPlanBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.disasterPlanBasedRecommendationServiceLevelObjectiveId")]
        public System.Guid? DisasterPlanBasedRecommendationServiceLevelObjectiveId { get; private set; }

        /// <summary>
        /// Gets or sets overallRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.overallRecommendationServiceLevelObjective")]
        public string OverallRecommendationServiceLevelObjective { get; private set; }

        /// <summary>
        /// Gets or sets overallRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.overallRecommendationServiceLevelObjectiveId")]
        public System.Guid? OverallRecommendationServiceLevelObjectiveId { get; private set; }

        /// <summary>
        /// Gets or sets confidence for service tier advisor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.confidence")]
        public double? Confidence { get; private set; }

    }
}
