namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    public class Authentication
    {
        public string SubscriptionId { get; set; }
        public string Tenant { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Certificate Certificate { get; set; }
    }
}
