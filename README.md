# AzureSqlDatabaseScale
A set of helper classes that can be  used from Azure Functions to scale an Azure SQL Database Up or Down.

Example of changing the DTU level of a Azure SQL Database based on alerts.

```
#r "AzureSqlDatabaseScale.dll"
#r "Hyak.Common.dll"
#r "Microsoft.Azure.Common.dll"
#r "Microsoft.Azure.Common.NetFramework.dll"
#r "Microsoft.Threading.Tasks.dll"
#r "Microsoft.Threading.Tasks.Extensions.Desktop.dll"
#r "Microsoft.Threading.Tasks.Extensions.dll"
#r "Microsoft.WindowsAzure.Management.Sql.dll"
#r "Newtonsoft.Json.dll"
#r "System.Net.Http.Extensions.dll"
#r "System.Net.Http.Primitives.dll"

using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;
using Newtonsoft.Json.Linq;
using AzureSqlDatabaseScale;

public static async Task Run(HttpRequestMessage req, TraceWriter log)
{
    string json = await req.Content.ReadAsStringAsync();
    JObject notification = JObject.Parse(json);

    var subscriptionId = (string)notification["context"]["subscriptionId"];
    var resourceName = (string)notification["context"]["resourceName"];
    // get the name of the alert
    var name = (string)notification["context"]["name"];

    var resource = resourceName.Split('/');
    var serverName = resource[0];
    var databaseName = resource[1];

    // get the certificate subject name
    var certificate = ConfigurationManager.AppSettings["certificate-" + subscriptionId];
    var password = ConfigurationManager.AppSettings["certificate-password-" + subscriptionId];
    
    var database = new SqlDatabase(subscriptionId, serverName, databaseName, certificate, password);

    bool changed = false;

    if (name == "Auto-Scale-Up")
    {
        changed = await database.ScaleUp();
    }

    if (name == "Auto-Scale-Down")
    {
         changed = await database.ChangeServiceObjective(SqlDatabase.S0);
    }
}
```
