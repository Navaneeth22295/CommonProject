using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MAFIL.Common.WebExtension
{
    public class DispatchService : IDispatchService
    {
        private IOptions<AppSettings> _options;
        protected RestClient _restClient;

        public DispatchService(IHttpClient httpClient, IOptions<AppSettings> options)
        {
            _options = options;
            _restClient = new RestClient(httpClient);
        }

        public HttpResponseMessage PerformGet(CustomHeader customHeader, RoutingInformation routingInformation)
        {
            var serviceInformation = string.Format(@"services/{0}/{1}/{2}", routingInformation.ModuleName, routingInformation.ServiceName, routingInformation.MethodName);
            return _restClient.GetResponseForRelativeURL(_options.Value.APIGatewayURL + serviceInformation, customHeader);
        }

        public HttpResponseMessage PerformPost(CustomHeader customHeader, RoutingInformation routingInformation, dynamic model)
        {
            var serviceInformation = string.Format(@"services/{0}/{1}/{2}", routingInformation.ModuleName, routingInformation.ServiceName, routingInformation.MethodName);
            return _restClient.PostData<dynamic, dynamic>(_options.Value.APIGatewayURL + serviceInformation, model, customHeader);
        }

        public HttpResponseMessage PerformPut(CustomHeader customHeader, RoutingInformation routingInformation, dynamic model)
        {
            var serviceInformation = string.Format(@"services/{0}/{1}/{2}", routingInformation.ModuleName, routingInformation.ServiceName, routingInformation.MethodName);
            return _restClient.PutData<dynamic, dynamic>(_options.Value.APIGatewayURL + serviceInformation, model, customHeader);
        }

        public HttpResponseMessage PerformDelete(CustomHeader customHeader, RoutingInformation routingInformation)
        {
            var serviceInformation = string.Format(@"services/{0}/{1}/{2}", routingInformation.ModuleName, routingInformation.ServiceName, routingInformation.MethodName);
            return _restClient.DeleteData(_options.Value.APIGatewayURL + serviceInformation, customHeader);
        }


    }
}
