namespace Microsoft.Azure.Management.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public class DatabaseResourceUsageMetricsFilter
    {
        private readonly List<string> _metrics;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResourceUsageMetricsFilter"/> class.
        /// </summary>
        /// <param name="startTime">Specifies the start time to retrieve.</param>
        /// <param name="endTime">Specifies the end time to retrieve.</param>
        /// <param name="metrics">The metrics.</param>
        public DatabaseResourceUsageMetricsFilter(DateTime startTime, DateTime endTime, params string[] metrics)
        {
            StartTime = startTime;
            EndTime = endTime;
            TimeGrain = TimeSpan.FromMinutes(5);
            _metrics = new List<string>(metrics);
        }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IList<string> Metrics => new ReadOnlyCollection<string>(_metrics);

        public TimeSpan? TimeGrain
        {
            get;
            set;
        }

        public void Include(params string[] metrics)
        {
            _metrics.AddRange(metrics);
        }

        public override string ToString()
        {
            StringBuilder filterBuilder = new StringBuilder();

            AppendMetrics(filterBuilder);
            AppendTimeGrain(filterBuilder);
            AppendDateRange(filterBuilder);

            return filterBuilder.ToString();
        }

        private void AppendMetrics(StringBuilder filterBuilder)
        {
            if (_metrics.Count == 0)
            {
                return;
            }

            if (_metrics.Count == 1)
            {
                filterBuilder.AppendFormat("name/value eq '{0}'", _metrics[0]);
                return;
            }

            filterBuilder.AppendFormat("(name/value eq '{0}'", _metrics[0]);

            for (int i = 1; i < _metrics.Count; i++)
            {
                filterBuilder.AppendFormat("or name/value eq '{0}'", _metrics[i]);
            }

            filterBuilder.Append(")");
        }

        private void AppendTimeGrain(StringBuilder filterBuilder)
        {
            if (TimeGrain.HasValue)
            {
                if (filterBuilder.Length != 0)
                {
                    filterBuilder.Append(" and ");
                }

                var grain = TimeGrain.Value;

                // Acceptable values are in increments of 5 minutes or 15 seconds if querying for the previous 1 hour of data.
                if (StartTime < DateTime.UtcNow.AddHours(-1))
                {
                    // must be multiple of 5 minutes, round up to 
                    grain = RoundToMinutes(grain, 5);
                }
                else
                {
                    grain = RoundToSeconds(grain, 15);
                }

                filterBuilder.AppendFormat("timeGrain eq '{0:c}'", grain);
            }

        }

        private void AppendDateRange(StringBuilder filterBuilder)
        {
            if (filterBuilder.Length != 0)
            {
                filterBuilder.Append(" and ");
            }

            filterBuilder.AppendFormat("startTime eq '{0:yyyy-MM-dd HH:mm:ss}' and endTime eq '{1:yyyy-MM-dd HH:mm:ss}'", StartTime, EndTime);
        }

        private TimeSpan RoundToMinutes(TimeSpan value, int n)
        {
            return TimeSpan.FromMinutes(n * Math.Ceiling(value.TotalMinutes / n));
        }

        private TimeSpan RoundToSeconds(TimeSpan value, int n)
        {
            return TimeSpan.FromSeconds(n * Math.Ceiling(value.TotalSeconds / n));
        }
    }
}