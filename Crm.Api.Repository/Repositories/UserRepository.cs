using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Api.Repository.Entities;
using Dapper;

namespace Crm.Account.Api.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnection;

        public UserRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<AccountUserDbO> GetUsersByAccountId(int accountId, bool getActiveUserOnlyFlag)
        {
            List<AccountUserDbO> userDbOs;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                userDbOs = connection.Query<AccountUserDbO>(
                    "dbo.spMR_GetAccountUsers",
                    new { AccountId = accountId, ShowDeactivatedUsers = !getActiveUserOnlyFlag }, commandType: CommandType.StoredProcedure).ToList();
            }
            return userDbOs;
        }

        public UserDbO GetUserById(int userId)
        {
            UserDbO userDbO;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                userDbO = connection.Query<UserDbO>(
                    "SELECT * FROM dbo.Users WHERE UserId = @userId",
                    new {UserId = userId}).FirstOrDefault();
            }
            return userDbO;
        }

        public UserDbO GetUserByAccountIdAndId(int accountId, int userId)
        {
            UserDbO userDbO;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                userDbO = connection.Query<UserDbO>(
                    "SELECT * FROM dbo.Users WHERE AccountId = @accountId And UserId = @userId",
                    new { AccountId = accountId, UserId = userId }).FirstOrDefault();
            }
            return userDbO;
        }

        public bool CheckUserExistsByUserId(int userId)
        {
            bool isExist;
            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                var result = connection.Query<int?>(
                    "SELECT TOP 1 UserId FROM dbo.Users WHERE UserId = @userId",
                    new { UserId = userId }).FirstOrDefault();

                isExist = result != null;
            }
            return isExist;
        }

        public List<string> GetLosUserNames(int userId)
        {
            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                var result = connection.Query<string>(
                    "SELECT LOSUserName FROM dbo.LOSUserNames WHERE UserId = @userId",
                    new { UserId = userId }).ToList();

                return result;
            }
        }

        public AccountUserEntity GetAcountUserEntity(int userId)
        {
            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                var result = connection.Query<AccountUserEntity>(
                    "SELECT * FROM dbo.AccountUsers WHERE UserId = @userId",
                    new { UserId = userId }).FirstOrDefault();

                return result;
            }
        }
    }
}
