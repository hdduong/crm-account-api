using System.Collections.Generic;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Interfaces.Services
{
    public interface IAccountService
    {
        Models.Response.Account GetAccountById(string accountId);
        List<RecordType> GetRecordTypes(string accountId);
        RecordType GetRecordTypeByAccountIdAndId(string accountId, string recordTypeId);
        List<int> GetAccountIds(bool getOnlyActiveAccountFlag);
        List<Models.Response.Account> GetAccountEntities(bool getOnlyActiveAccountFlag);
        List<int> GetRecordTypeIds(string accountId);
    }
}