namespace ResourceManagement.Extensions.Sql
{
    using System.Collections.Generic;

    public static class ServiceObjectiveExtensions
    {
        public static ServiceObjective After(this IEnumerable<ServiceObjective> items, ServiceObjective serviceObjective)
        {
            bool found = false;

            foreach (ServiceObjective item in items)
            {
                if (found)
                {
                    return item;
                }

                if (item.Id == serviceObjective.Id)
                {
                    found = true;
                }                
            }

            return null;
        }

        /// <summary>
        /// Gets the ServiceObjective before the specified service objective.
        /// </summary>
        /// <param name="items">The collection.</param>
        /// <param name="serviceObjective">The service objective.</param>
        /// <returns></returns>
        public static ServiceObjective Before(this IEnumerable<ServiceObjective> items, ServiceObjective serviceObjective)
        {
            ServiceObjective previous = null;

            foreach (ServiceObjective item in items)
            {
                if (item.Id == serviceObjective.Id)
                {
                    return previous;
                }

                previous = item;
            }

            return null;
        }        
    }
}