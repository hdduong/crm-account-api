using System.Collections.Generic;
using Crm.Account.Api.Repository.Entities;
using Crm.Api.Repository.Entities;

namespace Crm.Account.Api.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<AccountUserDbO> GetUsersByAccountId(int accountId, bool getActiveUserOnlyFlag);
        UserDbO GetUserById(int userId);
        UserDbO GetUserByAccountIdAndId(int accountId, int userId);
        bool CheckUserExistsByUserId(int userId);
        List<string> GetLosUserNames(int userId);
        AccountUserEntity GetAcountUserEntity(int userId);
    }
}