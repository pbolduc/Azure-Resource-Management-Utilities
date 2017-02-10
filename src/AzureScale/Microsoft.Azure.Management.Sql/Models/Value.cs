namespace Microsoft.Azure.Management.Sql.Models
{
    using System;

    public class Value
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public Name Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "timeGrain")]
        public string TimeGrain { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "startTime")]
        public DateTime StartTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "endTime")]
        public DateTime EndTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "metricValues")]
        public MetricValue[] MetricValues { get; set; }
    }
}