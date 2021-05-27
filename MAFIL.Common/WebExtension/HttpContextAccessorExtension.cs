using Microsoft.AspNetCore.Http;

namespace MAFIL.Common.WebExtension
{
    public static class HttpContextAccessorExtension
    {
        public static CustomHeader GetCustomHeader(this IHttpContextAccessor accessor)
        {
            return new CustomHeader
            {
                TenantName = accessor.HttpContext.Items["x-tenant-name"]?.ToString(),
                AccessToken = accessor.HttpContext.Items["x-access-token"]?.ToString(),
                CorrelationToken = accessor.HttpContext.Items["Correlation-Token"]?.ToString()
            };
        }
    }
}
