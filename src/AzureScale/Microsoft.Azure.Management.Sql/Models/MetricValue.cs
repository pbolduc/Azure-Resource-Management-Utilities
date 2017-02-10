namespace Microsoft.Azure.Management.Sql.Models
{
    using System;

    public class MetricValue
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "average")]
        public double Average { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum")]
        public double Minimum { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "maximum")]
        public double Maximum { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "total")]
        public double Total { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}