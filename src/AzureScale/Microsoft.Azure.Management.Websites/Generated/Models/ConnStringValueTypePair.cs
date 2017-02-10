// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Database connection string value to type pair.
    /// </summary>
    public partial class ConnStringValueTypePair
    {
        /// <summary>
        /// Initializes a new instance of the ConnStringValueTypePair class.
        /// </summary>
        public ConnStringValueTypePair() { }

        /// <summary>
        /// Initializes a new instance of the ConnStringValueTypePair class.
        /// </summary>
        /// <param name="value">Value of pair.</param>
        /// <param name="type">Type of database. Possible values include:
        /// 'MySql', 'SQLServer', 'SQLAzure', 'Custom', 'NotificationHub',
        /// 'ServiceBus', 'EventHub', 'ApiHub', 'DocDb', 'RedisCache'</param>
        public ConnStringValueTypePair(string value, ConnectionStringType? type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// Gets or sets value of pair.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets type of database. Possible values include: 'MySql',
        /// 'SQLServer', 'SQLAzure', 'Custom', 'NotificationHub',
        /// 'ServiceBus', 'EventHub', 'ApiHub', 'DocDb', 'RedisCache'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public ConnectionStringType? Type { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Value == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Value");
            }
        }
    }
}