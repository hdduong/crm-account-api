using System;
using System.Net;
using System.Threading.Tasks;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Service.Exception;
using Crm.Account.Api.Service.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Crm.Account.Api
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(context.TraceIdentifier + " " + ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            string result = null;

            if (exception is MyInvalidException myException)
            {
                if (myException.ErrorCode.ToLower().Equals(ErrorCodeCategory.CrmNotFound.ToString().ToLower()))
                {
                    code = HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject(new Error
                    {
                        ErrorCode = myException.ErrorCode,
                        Summary = ErrorMessage.NotFoundInputSummary,
                        Detail = myException.Message
                    });
                }
                else if (myException.ErrorCode.ToLower().Equals(ErrorCodeCategory.CrmInvalidInput.ToString().ToLower()))
                {
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new Error
                    {
                        ErrorCode = myException.ErrorCode,
                        Summary = ErrorMessage.InvalidInputSummary,
                        Detail = myException.Message
                    });
                }               

                // Todo. Aws.Nlog to log result and myException.InnerException
            }
            else if (exception is MyAuthorizationException myAuthException)
            {
                code = HttpStatusCode.Forbidden;
                result = JsonConvert.SerializeObject(new Error
                {
                    ErrorCode = myAuthException.ErrorCode,
                    Summary = ErrorMessage.JwtInvalid,
                    Detail = myAuthException.Message
                });
            }
            else
            {
                result = JsonConvert.SerializeObject(new Error
                {
                    ErrorCode = ErrorCodeCategory.CrmInternalServerError.ToString(),
                    Summary = ErrorMessage.InternalServerError,
                    Detail = exception.Message
                });
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
