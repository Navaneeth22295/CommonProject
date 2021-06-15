using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MAFIL.Common.Middlewares
{
    public class CustomSerilogMiddleware
    {
        const string _messageTemplate =  "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        static readonly ILogger _log = Log.ForContext<CustomSerilogMiddleware>();

        private readonly RequestDelegate _next;

        public CustomSerilogMiddleware(RequestDelegate next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));

            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var sw = Stopwatch.StartNew();
            try
            {
                await _next(httpContext);
                sw.Stop();

                var statusCode = httpContext.Response?.StatusCode;
                var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                var log = level == LogEventLevel.Error ? LogForErrorContext(httpContext) : _log;
                log.Write(level, _messageTemplate, httpContext.Request.Method, httpContext.Request.Path, statusCode, sw.Elapsed.TotalMilliseconds);
            }
            // Never caught, because `LogException()` returns false.
            catch (Exception ex) when (LogException(httpContext, sw, ex)) { }
        }

        static bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
        {
            sw.Stop();
            string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            LogForErrorContext(httpContext)
                .Error(msg, _messageTemplate, httpContext.Request.Method, httpContext.Request.Path, 500, sw.Elapsed.TotalMilliseconds);

            return false;
        }

        static ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var result = _log
                .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            if (request.HasFormContentType)
                result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

            return result;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomSerilogMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomSerilogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomSerilogMiddleware>();
        }
    }
}
