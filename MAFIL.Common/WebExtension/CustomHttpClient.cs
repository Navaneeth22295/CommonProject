using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MAFIL.Common.WebExtension
{
    public class CustomHttpClient : IHttpClient
    {
        private HttpClient _rootHttpClient;

        public CustomHttpClient()
        {
            _rootHttpClient = new HttpClient();
        }

        public Uri BaseAddress
        {
            get
            {
                return _rootHttpClient.BaseAddress;
            }
            set
            {
                _rootHttpClient.BaseAddress = value;
            }
        }

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return _rootHttpClient.DefaultRequestHeaders;
            }
        }

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return _rootHttpClient.DeleteAsync(requestUri);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            return _rootHttpClient.DeleteAsync(requestUri);
        }

        public void Dispose(bool disposing)
        {
            _rootHttpClient.Dispose();
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return _rootHttpClient.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var dd = _rootHttpClient.GetAsync(requestUri);

            return _rootHttpClient.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return _rootHttpClient.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return _rootHttpClient.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _rootHttpClient.PostAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _rootHttpClient.PostAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return _rootHttpClient.PutAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return _rootHttpClient.PutAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PutAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _rootHttpClient.PutAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _rootHttpClient.SendAsync(request);
        }
    }
}
