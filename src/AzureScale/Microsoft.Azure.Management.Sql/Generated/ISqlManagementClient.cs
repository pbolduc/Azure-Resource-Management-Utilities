// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Sql
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// The Azure SQL Database management API provides a RESTful set of web
    /// services that interact with Azure SQL Database services to manage
    /// your databases. The API enables you to create, retrieve, update, and
    /// delete databases.
    /// </summary>
    public partial interface ISqlManagementClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        Newtonsoft.Json.JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        Newtonsoft.Json.JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        Microsoft.Rest.ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// The subscription ID that identifies an Azure subscription.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running
        /// Operations. Default value is 30.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is
        /// generated and included in each request. Default is true.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }


        /// <summary>
        /// Gets the IServersOperations.
        /// </summary>
        IServersOperations Servers { get; }

        /// <summary>
        /// Gets the IDatabasesOperations.
        /// </summary>
        IDatabasesOperations Databases { get; }

        /// <summary>
        /// Gets the IElasticPoolsOperations.
        /// </summary>
        IElasticPoolsOperations ElasticPools { get; }

        /// <summary>
        /// Gets the IRecommendedElasticPoolsOperations.
        /// </summary>
        IRecommendedElasticPoolsOperations RecommendedElasticPools { get; }

    }
}
