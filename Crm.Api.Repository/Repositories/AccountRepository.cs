using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Dapper;

namespace Crm.Account.Api.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnectionFactory _dbConnection;

        public AccountRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public AccountDbO GetAccountById(int accountId)
        {
            AccountDbO accountDbO;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                accountDbO = connection.Query<AccountDbO>(
                    "dbo.spMR_GetAccountDataByAccountId",
                    new {AccountId = accountId}, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (accountDbO != null) accountDbO.AccountId = accountId;
            }

            return accountDbO;
        }

        public bool CheckAccountExistsByAcountId(int accountId)
        {
            bool isExist;
            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                var result = connection.Query<int?>(
                    "SELECT TOP 1 AccountId FROM dbo.Accounts WHERE AccountID = @accountId",
                    new {AccountId = accountId}).FirstOrDefault();

                isExist = result != null;
            }
            return isExist;
        }

        /// <summary>
        /// Get all account Ids
        /// </summary>
        /// <param name="getOnlyActiveAccountFlag">flag to determine only if active account returned</param>
        /// <returns></returns>
        public List<int> GetAllAccountIds(bool getOnlyActiveAccountFlag)
        {
            List<int> accountList;
            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                if (getOnlyActiveAccountFlag)
                {
                    accountList = connection
                        .Query<int>(
                            "SELECT AccountId FROM dbo.Accounts WHERE (StopDate IS NULL) OR  (StopDate >= GETDATE())")
                        .ToList();
                }
                else
                {
                    accountList = connection
                        .Query<int>(
                            "SELECT AccountId FROM dbo.Accounts")
                        .ToList();
                }

            }
            return accountList;
        }

        /// <summary>
        /// Get all account entities
        /// </summary>
        /// <param name="getOnlyActiveAccountFlag">flag to determine only if active account returned</param>
        /// <returns></returns>
        public List<AccountDbO> GetAccountEntities(bool getOnlyActiveAccountFlag)
        {
            var accountDbOs = new List<AccountDbO>();

            var accountIds = GetAllAccountIds(getOnlyActiveAccountFlag);

            foreach (var accountId in accountIds)
            {
                var accountDbO = GetAccountById(accountId);
                accountDbO.AccountId = accountId;
                accountDbOs.Add(accountDbO);
            }
            return accountDbOs;
        }
    }
}
