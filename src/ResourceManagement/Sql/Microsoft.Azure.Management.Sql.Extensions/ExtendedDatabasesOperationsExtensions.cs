namespace Microsoft.Azure.Management.Sql
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Models;

    public static class ExtendedDatabasesOperationsExtensions
    {
        /// <summary>
        /// Gets the resource usage details for an Azure SQL database that is either single or associated with an elastic pool..
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="databaseName">Specifies the name of the database. Case sensitive.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="Microsoft.Rest.SerializationException">Unable to deserialize the response.</exception>
        /// <remarks>
        /// The data is available for the last 14 days. Only the first 1000 records are returned for each request.
        /// Body of this method largely copied from the AutoRest generated members. Not sure why this API is not in the swagger specs.
        /// </remarks>
        public static async Task<DatabaseResourceUsageMetricsResponse> GetDatabaseResourceUsageMetricsAsync(this IExtendedDatabasesOperations operations,
            string resourceGroupName,
            string serverName,
            string databaseName,
            DatabaseResourceUsageMetricsFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatabaseResourceUsageMetricsWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, filter, cancellationToken))
            {
                return _result.Body;
            }
        }
    }
}