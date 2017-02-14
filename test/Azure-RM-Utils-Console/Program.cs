namespace AzureRMUtilsConsole
{
    using System;
    using System.IO;
    using Microsoft.Azure.Management.Sql;
    using Newtonsoft.Json;
    using ResourceManagement.Extensions.Sql.PriceTiers;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.Write("Usage: AzureRMUtilsConsole.exe config-file");
            }
            else
            {
                ViewDtuHistory(args[0]);
                ScaleDatabase(args[0]);
            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        private static void ScaleDatabase(string filename)
        {
            SqlDatabaseEnvironment config = GetConfiguration(filename);
            var client = new SqlManagementClient(config.Authentication.GetCredentials());
            client.SubscriptionId = config.Authentication.SubscriptionId;

            var resourceGroup = config.Databases[0].ResourceGroup;
            var serverName = config.Databases[0].Server;
            var databaseName = config.Databases[0].DatabaseName;
            var settings = config.Databases[0].Settings;

            PriceTierMonitor monitor = new PriceTierMonitor(Console.Out);


            var task = monitor.UpdatePriceTier(client, resourceGroup, serverName, databaseName, settings);
            task.Wait();
        }

        private static void ViewDtuHistory(string filename)
        {
            SqlDatabaseEnvironment config = GetConfiguration(filename);
            var client = new SqlManagementClient(config.Authentication.GetCredentials());
            client.SubscriptionId = config.Authentication.SubscriptionId;

            var resourceGroup = config.Databases[0].ResourceGroup;
            var serverName = config.Databases[0].Server;
            var databaseName = config.Databases[0].DatabaseName;

            var task = client.GetServiceObjectiveHistoryAsync(resourceGroup, serverName, databaseName);
            task.Wait();

            var levels = task.Result;

            Console.WriteLine($"It is now {DateTime.UtcNow}");
            foreach (var level in levels)
            {
                Console.WriteLine($"Database {level.Item3.Name} from {level.Item1} to {level.Item2}");
            }
        }

        private static SqlDatabaseEnvironment GetConfiguration(string filename)
        {
            var json = File.ReadAllText(filename);
            var config = JsonConvert.DeserializeObject<SqlDatabaseEnvironment>(json);
            return config;
        }
    }
}
