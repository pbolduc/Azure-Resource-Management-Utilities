namespace ResourceManagement.Extensions
{
    using System;

    internal static class TimeSpanExtensions
    {
        /// <summary>
        /// Rounds up the date to a multiple of the specified duration.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        public static DateTime RoundUp(this DateTime source, TimeSpan duration)
        {
            var modTicks = source.Ticks % duration.Ticks;
            var delta = modTicks != 0 ? duration.Ticks - modTicks : 0;
            return new DateTime(source.Ticks + delta, source.Kind);
        }

        /// <summary>
        /// Rounds down the date to a multiple of the specified duration.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        public static DateTime RoundDown(this DateTime source, TimeSpan duration)
        {
            var delta = source.Ticks % duration.Ticks;
            return new DateTime(source.Ticks - delta, source.Kind);
        }

        /// <summary>
        /// Rounds the date to the nearest multiple of the specified duration.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        public static DateTime RoundToNearest(this DateTime source, TimeSpan duration)
        {
            var delta = source.Ticks % duration.Ticks;
            bool roundUp = delta > duration.Ticks / 2;
            var offset = roundUp ? duration.Ticks : 0;

            return new DateTime(source.Ticks + offset - delta, source.Kind);
        }
    }
}