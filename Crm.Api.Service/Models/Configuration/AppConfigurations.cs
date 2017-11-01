using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Service.Models.Configuration
{
    [ExcludeFromCodeCoverage]
    public class AppConfigurations
    {
        public string JwtSecretKey { get; set; }
    }
}
