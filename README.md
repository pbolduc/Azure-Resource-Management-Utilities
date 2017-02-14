# Azure-Resource-Management-Utilities
The motivation for this project is to provide a set up utility libraries that make it easy to scale up or down your Azure SQL Database. 
The primary use case is when using Azure SQL Database for development, to keep the price tier as low as possible saving MSDN credits or
dev/test dollars.  It is not intended for scaling production work loads.

## Get Azure SQL Database Service Objective (DTU) History
Gets the changes to the price tier of a database for a given period of time. Is limited to the last 14 days.

        /// <summary>Gets the service objective history for the past 90 minutes</summary>
        public static Task<List<Tuple<DateTime, DateTime, ServiceObjective>>> GetServiceObjectiveHistoryAsync(
            this SqlManagementClient client,
            string resourceGroupName,
            string serverName,
            string databaseName);

        /// <summary>Gets the service objective history for the amount time time specified.</summary>
        public static async Task<List<Tuple<DateTime, DateTime, ServiceObjective>>> GetServiceObjectiveHistoryAsync(
            this SqlManagementClient client,
            string resourceGroupName,
            string serverName,
            string databaseName,
            TimeSpan timeRange);
 
## Monitor and Change Azure SQL Database Service Objective

The class [PriceTierMonitor](https://github.com/pbolduc/Azure-Resource-Management-Utilities/blob/develop/src/Azure-RM-Utils/Sql/PriceTiers/PriceTierMonitor.cs)
can be called with a set of settings to automatically scale up or down an Azure SQL Database
