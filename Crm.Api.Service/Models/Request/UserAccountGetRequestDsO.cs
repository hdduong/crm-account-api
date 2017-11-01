using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Service.Models.Request
{
    [ExcludeFromCodeCoverage]
    public class AccountUserGetRequestDsO
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }

        public AccountUserGetRequestDsO(string accountId, string userId)
        {
            AccountId = accountId;
            UserId = userId;
        }
    }
}
