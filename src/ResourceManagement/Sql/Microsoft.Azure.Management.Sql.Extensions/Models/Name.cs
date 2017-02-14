namespace Microsoft.Azure.Management.Sql.Models
{
    public class Name
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "localizedValue")]
        public string LocalizedValue { get; set; }
    }
}