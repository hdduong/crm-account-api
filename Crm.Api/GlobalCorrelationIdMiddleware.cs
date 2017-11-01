using System;
using System.Threading.Tasks;
using Crm.Account.Api.Constant;
using Crm.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Crm.Account.Api
{
    public class GlobalCorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalCorrelationIdMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext context)
        {
            string correlationId = context.Request.Headers[ApiConstant.CorrelationIdHeaderName];
            if (string.IsNullOrEmpty(correlationId))
            {
                context.TraceIdentifier = Guid.NewGuid().ToString();
            }
            else
            {
                context.TraceIdentifier = correlationId;
            }
           
            context
                .Response
                .Headers
                .Add(ApiConstant.CorrelationIdHeaderName, context.TraceIdentifier);

            return _next(context);
        }
    }
}
