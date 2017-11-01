namespace Crm.Account.Api.Service.Interfaces.Services
{
    public interface IShareService
    {
        bool AssertAccountValid(string accountId);
        bool AssertUserValid(string userId);
        bool AssertRecordTypeValid(string recordTypeId);
        bool AssertAccountRecordTypeValid(string accountId, string recordTypeId);
        string GetLosNameById(int losId);
    }
}