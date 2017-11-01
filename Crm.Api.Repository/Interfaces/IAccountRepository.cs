using System.Collections.Generic;
using Crm.Account.Api.Repository.Entities;

namespace Crm.Account.Api.Repository.Interfaces
{
    public interface IAccountRepository
    {
        AccountDbO GetAccountById(int accountId);
        bool CheckAccountExistsByAcountId(int accountId);
        List<int> GetAllAccountIds(bool getOnlyActiveAccountFlag);
        List<AccountDbO> GetAccountEntities(bool getOnlyActiveAccountFlag);
    }
}