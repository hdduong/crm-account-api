using System.Collections.Generic;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Interfaces.Services
{
    public interface IRecordTypeService
    {
        List<RecordType> GetListRecordTypeForAccountWithoutValidation(string accountId);
        List<int> GetListRecordTypeIdForAccountWithoutValidation(string accountId);
        RecordType GetRecordTypeByIdWithoutValidation(string recordTypeId);
        RecordType GetRecordTypeByAccountIdAndIdWithoutValidation(string accountId, string recordTypeId);
        RecordType GetRecordTypeById(string recordTypeId);
    }
}