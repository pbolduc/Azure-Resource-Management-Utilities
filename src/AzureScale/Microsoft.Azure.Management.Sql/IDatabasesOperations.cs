namespace Microsoft.Azure.Management.Sql
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.Rest.Azure;

    public partial interface IDatabasesOperations
    {
        Task<AzureOperationResponse<DatabaseResourceUsageMetricsResponse>> GetDatabaseResourceUsageMetricsWithHttpMessagesAsync(
            string resourceGroupName,
            string serverName,
            string databaseName,
            DatabaseResourceUsageMetricsFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
