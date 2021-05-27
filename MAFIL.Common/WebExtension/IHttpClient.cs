using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MAFIL.Common.WebExtension
{
    public interface IHttpClient
    {
        Uri BaseAddress { get; set; }

        HttpRequestHeaders DefaultRequestHeaders { get; }
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
        Task<HttpResponseMessage> DeleteAsync(Uri requestUri);

        void Dispose(bool disposing);

        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> GetAsync(Uri requestUri);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);

        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
        Task<HttpResponseMessage> PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, HttpContent content, CancellationToken cancellationToken);

        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
