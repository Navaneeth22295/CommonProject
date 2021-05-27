using System.Net.Http;

namespace MAFIL.Common.WebExtension
{
    public interface IDispatchService
    {
        HttpResponseMessage PerformGet(CustomHeader customHeader, RoutingInformation routingInformation);
        HttpResponseMessage PerformPost(CustomHeader customHeader, RoutingInformation routingInformation, dynamic model);
        HttpResponseMessage PerformPut(CustomHeader customHeader, RoutingInformation routingInformation, dynamic model);
        HttpResponseMessage PerformDelete(CustomHeader customHeader, RoutingInformation routingInformation);
    }
}
