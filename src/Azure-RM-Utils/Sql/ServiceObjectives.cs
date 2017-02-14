namespace ResourceManagement.Extensions.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Contains the service object identifiers from SQL Azure.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/azure/dn505723.aspx"/>
    /// </summary>
    public static class ServiceObjectives
    {
        public static readonly ServiceObjective None = new ServiceObjective(string.Empty, 0, string.Empty, Guid.Empty);

        /// <summary>
        /// Basic resource allocation (5 DTU).
        /// </summary>
        public static readonly ServiceObjective Basic = new ServiceObjective("Basic", 5, "Basic", new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"));

        /// <summary>
        /// Standard S0 resource allocation (10 DTU).
        /// </summary>
        public static readonly ServiceObjective S0 = new ServiceObjective("Standard", 10, "S0", new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b"));
        
        /// <summary>
        /// Standard S1 resource allocation (20 DTU).
        /// </summary>
        public static readonly ServiceObjective S1 = new ServiceObjective("Standard", 20, "S1", new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"));

        /// <summary>
        /// Standard S2 resource allocation (50 DTU).
        /// </summary>
        public static readonly ServiceObjective S2 = new ServiceObjective("Standard", 50, "S2", new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"));

        /// <summary>
        /// Standard S3 resource allocation (100 DTU).
        /// </summary>
        public static readonly ServiceObjective S3 = new ServiceObjective("Standard", 100, "S3", new Guid("789681b8-ca10-4eb0-bdf2-e0b050601b40"));

        /// <summary>
        /// Premium P1 resource allocation.
        /// </summary>
        public static readonly ServiceObjective P1 = new ServiceObjective("Premium", 125, "P1",new Guid("7203483a-c4fb-4304-9e9f-17c71c904f5d"));
        
        /// <summary>
        /// Premium P2 resource allocation.
        /// </summary>
        public static readonly ServiceObjective P2 = new ServiceObjective("Premium", 250, "P2", new Guid("a7d1b92d-c987-4375-b54d-2b1d0e0f5bb0"));
        
        /// <summary>
        /// Premium P4 resource allocation.
        /// </summary>
        public static readonly ServiceObjective P4 = new ServiceObjective("Premium", 500, "P4", new Guid("afe1eee1-1f12-4e5f-9ad6-2de9c12cb4dc"));
        
        /// <summary>
        /// Premium P6 resource allocation.
        /// </summary>
        public static readonly ServiceObjective P6 = new ServiceObjective("Premium", 1000, "P6", new Guid("43940481-9191-475a-9dba-6b505615b9aa"));
        
        /// <summary>
        /// Premium P11 resource allocation.
        /// </summary>
        public static readonly ServiceObjective P11 = new ServiceObjective("Premium", 1750, "P11", new Guid("dd00d544-bbc0-4f61-ba60-cdce0c410288"));
        
        /// <summary>
        /// Premium P15 resource allocation.
        /// </summary>
        public static readonly ServiceObjective P15 = new ServiceObjective("Premium", 4000, "P15", new Guid("5bc86cca-9a96-4a94-90ef-bbdfcfbf2d71"));

        public static IList<ServiceObjective> All = new ReadOnlyCollection<ServiceObjective>(new [] { Basic, S0, S1, S2, S3, P1, P2, P4, P6, P11, P15 });
        public static IList<ServiceObjective> Standard = new ReadOnlyCollection<ServiceObjective>(new [] { S0, S1, S2, S3 });
        public static IList<ServiceObjective> Premium = new ReadOnlyCollection<ServiceObjective>(new [] { P1, P2, P4, P6, P11, P15 });

        /// <summary>
        /// Finds the ServiceObjective by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The ServiceObjective or null if it was not found.</returns>
        public static ServiceObjective Find(Guid id)
        {
            return All.SingleOrDefault(_ => _.Id == id);
        }
    }
}
