namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    public class SqlDatabaseEnvironment
    {
        public Authentication Authentication { get; set; }
        public DatabaseConfiguration[] Databases { get; set; }
    }
}