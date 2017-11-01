namespace Crm.Account.Api.Service.Models.Request
{
    public class AccountRecordTypeGetRequestDsO
    {
        public AccountRecordTypeGetRequestDsO(string accountId, string recordTypeId)
        {
            AccountId = accountId;
            RecordTypeId = recordTypeId;
        }

        public string AccountId { get; set; }
        public string RecordTypeId { get; set; }
    }
}
