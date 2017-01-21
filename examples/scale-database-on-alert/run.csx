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

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    string json = await req.Content.ReadAsStringAsync();
    JObject notification = JObject.Parse(json);

    var subscriptionId = (string)notification["context"]["subscriptionId"];
    var resourceName = (string)notification["context"]["resourceName"];        
    var name = (string)notification["context"]["name"];

    var resource = resourceName.Split('/');
    var serverName = resource[0];
    var databaseName = resource[1];

    var thumbprint = ConfigurationManager.AppSettings["certificate-" + subscriptionId];
    X509Certificate2 certificate = CertificateUtil.GetCertificate(X509FindType.FindByThumbprint, thumbprint);
    
    SqlDatabase database = new SqlDatabase(subscriptionId, serverName, databaseName, certificate);
    var result = await database.ChangeServiceObjective(ServiceObjectives.S0);

    return result == HttpStatusCode.OK
        ? req.CreateResponse(HttpStatusCode.OK, "Changed")
        : req.CreateResponse(HttpStatusCode.OK, "Not Changed");
}
