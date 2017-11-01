using System.Threading.Tasks;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Crm.Account.Api
{
    public class GlobalJwtValidationMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly AppConfigurations _appConfiguration;
        private readonly IEllieJwtService _ellieJwtService;

        public GlobalJwtValidationMiddleware(RequestDelegate next, IOptions<AppConfigurations> appConfiguration,
            IEllieJwtService ellieJwtService)
        {
            _next = next;
            _appConfiguration = appConfiguration.Value;
            _ellieJwtService = ellieJwtService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().StartsWith("/api/"))
            {
                string jwt = context.Request.Headers["Authorization"];
                string encodedSecret = _appConfiguration.JwtSecretKey;

                _ellieJwtService.Validate(jwt, encodedSecret);

            }

            await _next.Invoke(context);
        }
    }
}
