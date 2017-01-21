namespace AzureSqlDatabaseScale
{
    using System;

    /// <summary>
    /// Contains the service object identifiers from SQL Azure.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/azure/dn505723.aspx"/>
    /// </summary>
    public static class ServiceObjectives
    {
        /// <summary>
        /// Basic resource allocation (5 DTU).
        /// </summary>
        public const string Basic = "dd6d99bb-f193-4ec1-86f2-43d3bccbc49c";

        /// <summary>
        /// Standard S0 resource allocation (10 DTU).
        /// </summary>
        public const string S0 = "f1173c43-91bd-4aaa-973c-54e79e15235b";
        
        /// <summary>
        /// Standard S1 resource allocation (20 DTU).
        /// </summary>
        public const string S1 = "1b1ebd4d-d903-4baa-97f9-4ea675f5e928";

        /// <summary>
        /// Standard S2 resource allocation (50 DTU).
        /// </summary>
        public const string S2 = "455330e1-00cd-488b-b5fa-177c226f28b7";

        /// <summary>
        /// Standard S3 resource allocation (100 DTU).
        /// </summary>
        public const string S3 = "789681b8-ca10-4eb0-bdf2-e0b050601b40";

        public const string P1 = "7203483a-c4fb-4304-9e9f-17c71c904f5d";
        public const string P2 = "a7d1b92d-c987-4375-b54d-2b1d0e0f5bb0";
        public const string P4 = "todo-4";
        public const string P6 = "todo-6";
        public const string P11 = "todo-11";
        public const string P15 = "todo-15";

        public static string Standard(int dtu)
        {
            if (dtu == 10) return S0;
            if (dtu == 20) return S1;
            if (dtu == 50) return S2;
            if (dtu == 100) return S3;

            throw new ArgumentOutOfRangeException(nameof(dtu), "Standard DTU levels must be 10, 20, 50 or 100.");
        }

        public static string Premium(int dtu)
        {
            if (dtu == 125) return P1;
            if (dtu == 250) return P2;
            if (dtu == 500) return P4;
            if (dtu == 1000) return P6;
            if (dtu == 1750) return P11;
            if (dtu == 4000) return P15;

            throw new ArgumentOutOfRangeException(nameof(dtu), "Premium DTU levels must be 125, 250, 500, 1000, 1750 or 4000.");
        }
    }
}