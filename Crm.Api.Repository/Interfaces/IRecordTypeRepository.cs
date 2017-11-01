using System.Collections.Generic;
using Crm.Account.Api.Repository.Entities;

namespace Crm.Account.Api.Repository.Interfaces
{
    public interface IRecordTypeRepository
    {
        List<RecordTypeDbO> GetRecordTypeByAccountId(int accountId);
        RecordTypeDbO GetRecordTypeById(int recordTypeId);
        RecordTypeDbO GetRecordTypeByAccountIdAndId(int accountId, int recordTypeId);
    }
}