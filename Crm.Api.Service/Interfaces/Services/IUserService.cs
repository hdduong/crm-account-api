using System.Collections.Generic;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Interfaces.Services
{
    public interface IUserService
    {
        List<AccountUser> GetListUsersForAccountWithoutValidation(string accountId, bool getActiveUserOnlyFlag);
        User GetUserByIdWithoutValidation(string userId);
        List<AccountUser> GetListUsersForAccount(string accountId, bool getActiveUserOnlyFlag);
        User GetUserById(string userId);
        User GetUserByAccountIdAndIdWithoutValidation(string accountId, string userId);
        List<int> GetListUserIdForAccount(string accountId, bool getActiveUserOnlyFlag);
        List<int> GetListUserIdsForAccountWithoutValidation(string accountId, bool getActiveUserOnlyFlag);
        List<AccountUser> GetUsers(bool getActiveUserOnlyFlag);
        List<int> GetUserIds(bool getActiveUserOnlyFlag);
    }
}