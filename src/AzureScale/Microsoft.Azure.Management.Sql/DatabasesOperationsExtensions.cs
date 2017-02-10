namespace Microsoft.Azure.Management.Sql
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Models;

    public static partial class DatabasesOperationsExtensions
    {
        public static async Task<DatabaseResourceUsageMetricsResponse> GetDatabaseResourceUsageMetricsAsync(this IDatabasesOperations operations,
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