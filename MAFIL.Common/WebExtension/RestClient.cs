using Newtonsoft.Json;
using Polly;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace MAFIL.Common.WebExtension
{
    public class RestClient
    {
        private const string TOKEN_NAME = "x-access-token";
        private const string TENANT_NAME = "tenant-name";
        private const string CORRELATION_TOKEN = "correlation-token";
        private IHttpClient _httpClient;

        public RestClient(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static Policy exponentialRetryPolicy = Policy.Handle<Exception>().WaitAndRetry(3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));

        //public U GetRawResultForRelativeURL<T, U>(string relativeUrl, CustomHeader customHeader, bool accessToeknRequired = true)
        //{
        //    var responseMessage = GetResponseForRelativeURL(relativeUrl, customHeader, accessToeknRequired);
        //    var result = responseMessage.Content.ReadAsStringAsync().Result;
        //    var resultModels = Mapper.Map<T, U>(JsonConvert.DeserializeObject<T>(result));
        //    return resultModels;
        //}

        public T GetRawResultForRelativeURL<T>(string relativeUrl, CustomHeader customHeader, bool accessToeknRequired = true)
        {
            var responseMessage = GetResponseForRelativeURL(relativeUrl, customHeader, accessToeknRequired);
            var resultObject = JsonConvert.DeserializeObject<T>(responseMessage.Content.ReadAsStringAsync().Result);
            return resultObject;
        }

        public HttpResponseMessage GetResponseForRelativeURL(string url, CustomHeader customHeader, bool accessToeknRequired = true)
        {
            AddHeadersToRequest(customHeader, accessToeknRequired);
            return exponentialRetryPolicy.Execute(() => _httpClient.GetAsync(url).Result);
        }

        public HttpResponseMessage PostData<TOutput, TInput>(string url,
            TInput data,
            CustomHeader customHeader,
            bool accessToeknRequired = true)
        {
            AddHeadersToRequest(customHeader, accessToeknRequired);
            return exponentialRetryPolicy.Execute(() => _httpClient.PostAsync<TOutput>(url, ConvertToValidRequestBody(data), default(CancellationToken))).Result;
        }

        public HttpResponseMessage PutData<TOutput, TInput>(string url,
            TInput data,
            CustomHeader customHeader,
            bool accessToeknRequired = true)
        {
            AddHeadersToRequest(customHeader, accessToeknRequired);
            return exponentialRetryPolicy.Execute(() => _httpClient.PutAsync<TOutput>(url, ConvertToValidRequestBody(data), default(CancellationToken))).Result;
        }

        public HttpResponseMessage DeleteData(string url, CustomHeader customHeader, bool accessToeknRequired = true)
        {
            AddHeadersToRequest(customHeader, accessToeknRequired);
            return exponentialRetryPolicy.Execute(() => _httpClient.DeleteAsync(url).Result);
        }

        private void AddHeadersToRequest(CustomHeader customHeader, bool accessToeknRequired)
        {
            //  _httpClient.DefaultRequestHeaders.Add(TENANT_NAME, customHeader.TenantName);
            _httpClient.DefaultRequestHeaders.Add(CORRELATION_TOKEN, customHeader.CorrelationToken);

            if (accessToeknRequired)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TOKEN_NAME, customHeader.AccessToken);
                _httpClient.DefaultRequestHeaders.Add(TOKEN_NAME, customHeader.AccessToken);// this code should nnot be there. will fix later

            }
        }

        private StringContent ConvertToValidRequestBody<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
