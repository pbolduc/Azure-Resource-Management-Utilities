namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql;

    public static class SqlManagementClientExtensions
    {
        public static Task<List<Tuple<DateTime, DateTime, ServiceObjective>>> GetServiceObjectiveHistoryAsync(
            this SqlManagementClient client,
            string resourceGroupName,
            string serverName,
            string databaseName)
        {
            return GetServiceObjectiveHistoryAsync(client, resourceGroupName, serverName, databaseName, TimeSpan.FromMinutes(90));
        }

        public static async Task<List<Tuple<DateTime, DateTime, ServiceObjective>>> GetServiceObjectiveHistoryAsync(
            this SqlManagementClient client,
            string resourceGroupName,
            string serverName,
            string databaseName,
            TimeSpan timeRange)
        {
            // must query for more than the last hour otherwise previous metric values will be zero
            var requestedTimeRange = timeRange;
            if (timeRange <= TimeSpan.FromHours(1))
            {
                timeRange = TimeSpan.FromHours(2);
            }

            DateTime end = DateTime.UtcNow.RoundUp(TimeSpan.FromMinutes(5));
            DateTime start = end.Subtract(timeRange);

            var longFilter = new DatabaseResourceUsageMetricsFilter(start, end, TimeSpan.FromMinutes(5), "dtu_limit");
            var response = await client.DatabaseExtensions().GetDatabaseResourceUsageMetricsAsync(resourceGroupName, serverName, databaseName, longFilter);

            // now get the recent history - the longer history may not show the recent changes to DTU level
            var shortFilter = new DatabaseResourceUsageMetricsFilter(end.Subtract(TimeSpan.FromMinutes(15)), end, TimeSpan.FromSeconds(30), "dtu_limit");
            var responseRecent = await client.DatabaseExtensions().GetDatabaseResourceUsageMetricsAsync(resourceGroupName, serverName, databaseName, shortFilter);

            var values = response.Values[0].MetricValues;
            var chunks = values.ChunkBy(_ => Convert.ToInt32(_.Average));
            var items = new List<Tuple<DateTime, DateTime, ServiceObjective>>();

            foreach (var chunk in chunks)
            {
                ServiceObjective serviceObjective = ServiceObjectives.All.Single(_ => _.Dtu == chunk.Key);
                var times = chunk.ToList();
                var dtuStart = times[0].Timestamp;
                var dtuEnd = times[times.Count - 1].Timestamp;

                items.Add(Tuple.Create(dtuStart, dtuEnd, serviceObjective));
            }

            var recentMetrics = responseRecent.Values[0].MetricValues;

            if (recentMetrics[0].Average == 0.0)
            {
                var changedAt = recentMetrics.First(_ => _.Average != 0);
                var lastTime = recentMetrics.Last().Timestamp;

                // find the above coarse item
                if (items.Count != 0)
                {
                    var item = items[items.Count - 1];

                    if (item.Item3.Dtu == Convert.ToInt32(changedAt.Average))
                    {
                        // adjust when this item changed
                        items[items.Count - 1] = Tuple.Create(changedAt.Timestamp, item.Item2, item.Item3);
                        if (1 < items.Count)
                        {
                            item = items[items.Count - 2];
                            items[items.Count - 2] = Tuple.Create(item.Item1, changedAt.Timestamp.Subtract(TimeSpan.FromSeconds(1)), item.Item3);
                        }
                    }
                    else
                    {
                        // the recently changed item does not show up in the longer history
                        items[items.Count - 1] = Tuple.Create(item.Item1, changedAt.Timestamp.Subtract(TimeSpan.FromSeconds(1)), item.Item3);
                        items.Add(Tuple.Create(changedAt.Timestamp, lastTime, ServiceObjectives.All.Single(_ => _.Dtu == Convert.ToInt32(changedAt.Average))));
                    }
                }
            }

            return items;
        }
       
    }
}