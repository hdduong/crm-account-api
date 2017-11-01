namespace Crm.Account.Api.Service.Models.Request
{
    public class RecordTypeGetRequestDsO
    {
        public string RecordTypeId { get; set; }

        public RecordTypeGetRequestDsO(string recordTypeId)
        {
            RecordTypeId = recordTypeId;
        }
    }
}
