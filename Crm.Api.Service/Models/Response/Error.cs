using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Crm.Account.Api.Service.Models.Response
{
    [ExcludeFromCodeCoverage]
    public class Error
    {
        [JsonProperty(PropertyName = "code")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }
    }
}
