# AzureSqlDatabaseScale
A set of helper classes that can be  used from Azure Functions to scale an Azure SQL Database Up or Down.


# Setup

https://blogs.msdn.microsoft.com/tomholl/2015/06/18/authenticating-to-azure-resource-manager-using-aad-and-certificates/


Example of changing the DTU level of a Azure SQL Database based on alerts.

```
#r "..\shared\AzureSqlDatabaseScale.dll"
#r "..\shared\Hyak.Common.dll"
#r "..\shared\Microsoft.Azure.Common.dll"
#r "..\shared\Microsoft.Azure.Common.NetFramework.dll"
#r "..\shared\Microsoft.Threading.Tasks.dll"
#r "..\shared\Microsoft.Threading.Tasks.Extensions.Desktop.dll"
#r "..\shared\Microsoft.Threading.Tasks.Extensions.dll"
#r "..\shared\Microsoft.WindowsAzure.Management.Sql.dll"
#r "..\shared\Newtonsoft.Json.dll"
#r "..\shared\System.Net.Http.Extensions.dll"
#r "..\shared\System.Net.Http.Primitives.dll"

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

    // get the certificate
    var thumbprint = ConfigurationManager.AppSettings["certificate-" + subscriptionId];
    X509Certificate2 certificate = CertificateUtil.GetCertificate(X509FindType.FindByThumbprint, thumbprint);
    
    var database = new SqlDatabase(subscriptionId, serverName, databaseName, certificate);

    if (name == "Auto-Scale-Up")
    {
        HttpStatusCode result = await database.ScaleUp();
    }

    if (name == "Auto-Scale-Down")
    {
         //HttpStatusCode result = await database.ScaleDown();
         HttpStatusCode result = await database.ChangeServiceObjective(SqlDatabase.S0);
    }
    
    return req.CreateResponse(HttpStatusCode.OK);
}
```
