namespace Crm.Account.Api.Service.Models.Request
{
    public class AccountGetRequestDsO
    {
        public AccountGetRequestDsO(string accountId)
        {
            AccountId = accountId;
        }
        public string AccountId { get; set; }
    }
}
