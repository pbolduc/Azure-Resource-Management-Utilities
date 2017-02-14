namespace Microsoft.Azure.Management.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.Rest.Azure;

    internal class ExtendedDatabasesOperations : Microsoft.Rest.IServiceOperations<SqlManagementClient>, IExtendedDatabasesOperations
    {
        /// <summary>
        /// Initializes a new instance of the DatabasesOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal ExtendedDatabasesOperations(SqlManagementClient client)
        {
            if (client == null) 
            {
                throw new System.ArgumentNullException("client");
            }
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the SqlManagementClient
        /// </summary>
        public SqlManagementClient Client { get; private set; }

        /// <summary>
        /// Gets the resource usage details for an Azure SQL database that is either single or associated with an elastic pool..
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="databaseName">Specifies the name of the database. Case sensitive.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="Microsoft.Rest.SerializationException">Unable to deserialize the response.</exception>
        /// <remarks>
        /// The data is available for the last 14 days. Only the first 1000 records are returned for each request.
        /// Body of this method largely copied from the AutoRest generated members. Not sure why this API is not in the swagger specs.
        /// </remarks>
        public async Task<AzureOperationResponse<DatabaseResourceUsageMetricsResponse>> GetDatabaseResourceUsageMetricsWithHttpMessagesAsync(
            string resourceGroupName,
            string serverName,
            string databaseName,
            DatabaseResourceUsageMetricsFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string apiVersion = "2014-04-01";
            // Tracing
            bool _shouldTrace = Rest.ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = Rest.ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("apiVersion", apiVersion);
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("serverName", serverName);
                tracingParameters.Add("databaseName", databaseName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                Rest.ServiceClientTracing.Enter(_invocationId, this, "GetDatabaseResourceUsageMetrics", tracingParameters);
            }

            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/metrics").ToString();
            _url = _url.Replace("{subscriptionId}", Uri.EscapeDataString(Client.SubscriptionId));
            _url = _url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            _url = _url.Replace("{serverName}", Uri.EscapeDataString(serverName));
            _url = _url.Replace("{databaseName}", Uri.EscapeDataString(databaseName));

            List<string> _queryParameters = new List<string>();
            if (apiVersion != null)
            {
                _queryParameters.Add($"api-version={Uri.EscapeDataString(apiVersion)}");
            }

            _queryParameters.Add($"$filter={Uri.EscapeDataString(filter.ToString())}");

            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }

            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = HttpMethod.Get;
            _httpRequest.RequestUri = new Uri(_url);

            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }

            //if (customHeaders != null)
            //{
            //    foreach(var _header in customHeaders)
            //    {
            //        if (_httpRequest.Headers.Contains(_header.Key))
            //        {
            //            _httpRequest.Headers.Remove(_header.Key);
            //        }
            //        _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
            //    }
            //}

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                Rest.ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                Rest.ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            System.Net.HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 204)
            {
                var ex = new Rest.Azure.CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null)
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else
                {
                    _responseContent = string.Empty;
                }
                ex.Request = new Rest.HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new Rest.HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    Rest.ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new Microsoft.Rest.Azure.AzureOperationResponse<DatabaseResourceUsageMetricsResponse>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<DatabaseResourceUsageMetricsResponse>(_responseContent, this.Client.DeserializationSettings);
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new Microsoft.Rest.SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                Microsoft.Rest.ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }
    }
}