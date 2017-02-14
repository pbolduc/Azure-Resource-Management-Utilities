namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    public class DatabaseConfiguration
    {
        public string ResourceGroup { get; set; }
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public DatabasePriceTierSetting[] Settings { get; set; }
    }
}