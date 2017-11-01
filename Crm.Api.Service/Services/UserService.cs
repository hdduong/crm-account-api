using System;
using System.Collections.Generic;
using AutoMapper;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;
using Crm.Api.Repository.Entities;

namespace Crm.Account.Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IShareService _shareService;
        private readonly IAccountService _accountService;

        public UserService(IUserRepository userRepository, IMapper mapper, IShareService shareService, 
            IAccountService accountService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _shareService = shareService;
            _accountService = accountService;
        }

        public List<AccountUser> GetListUsersForAccountWithoutValidation(string accountId, bool getActiveUserOnlyFlag)
        {
            // here means valid account (unsigned integer type and valid in db)
            var validAccountId = Int32.Parse(accountId);
            var userDbOs = _userRepository.GetUsersByAccountId(validAccountId, getActiveUserOnlyFlag);
            var users = _mapper.Map<List<AccountUserDbO>, List<AccountUser>>(userDbOs);

            return users;
        }

        public List<int> GetListUserIdsForAccountWithoutValidation(string accountId, bool getActiveUserOnlyFlag)
        {
            var userIds = new List<int>();
            var validAccountId = Int32.Parse(accountId);
            var userDbOs = _userRepository.GetUsersByAccountId(validAccountId, getActiveUserOnlyFlag);

            foreach (var userDbO in userDbOs)
            {
                userIds.Add(userDbO.UserId);
            }
            return userIds;
        }

        public User GetUserByIdWithoutValidation(string userId)
        {
            // here means valid userId (unsigned integer type and valid in db)
            var validUserId = Int32.Parse(userId);
            var userDbO = _userRepository.GetUserById(validUserId);
            var user = _mapper.Map<UserDbO, User>(userDbO);

            // get list of losUsernames
            var losUsernames = _userRepository.GetLosUserNames(validUserId);
            user.LosUserNames = losUsernames;

            // some fields are from dbo.AccountUsers table 
            var accountUserEntity = _userRepository.GetAcountUserEntity(validUserId);
            user.MayViewOtherLoHotlists = accountUserEntity.MayViewOtherLoHotlists;
            user.MayCreateTemplates = accountUserEntity.MayCreateTemplates;
            return user;
        }

        public User GetUserByAccountIdAndIdWithoutValidation(string accountId, string userId)
        {
            var validAccountId = Int32.Parse(accountId);
            var validUserId = Int32.Parse(userId);

            var userDbO = _userRepository.GetUserByAccountIdAndId(validAccountId, validUserId);
            var user = _mapper.Map<UserDbO, User>(userDbO);

            return user;
        }

        public List<AccountUser> GetListUsersForAccount(string accountId, bool getActiveUserOnlyFlag)
        {
            var result = _shareService.AssertAccountValid(accountId);
            return GetListUsersForAccountWithoutValidation(accountId, getActiveUserOnlyFlag);
        }

        public List<int> GetListUserIdForAccount(string accountId, bool getActiveUserOnlyFlag)
        {
            var result = _shareService.AssertAccountValid(accountId);
            return GetListUserIdsForAccountWithoutValidation(accountId, getActiveUserOnlyFlag);
        }

        public User GetUserById(string userId)
        {
            var result = _shareService.AssertUserValid(userId);
            return GetUserByIdWithoutValidation(userId);
        }

        /// <summary>
        /// Get all users for all accounts
        /// </summary>
        /// <param name="getActiveUserOnlyFlag">Get active users flag</param>
        /// <returns></returns>
        public List<AccountUser> GetUsers(bool getActiveUserOnlyFlag)
        {
            var users = new List<AccountUser>();

            // get all active accounts. Assume that if account is disabled then users are inactive
            var accountIds = _accountService.GetAccountIds(getActiveUserOnlyFlag);

            foreach (var accountId in accountIds)
            {
                var accountUserList = GetListUsersForAccountWithoutValidation(accountId.ToString(), getActiveUserOnlyFlag);
                users.AddRange(accountUserList);
            }
            return users;
        }

        /// <summary>
        /// Get all users for all accounts
        /// </summary>
        /// <param name="getActiveUserOnlyFlag">Get active users flag</param>
        /// <returns></returns>
        public List<int> GetUserIds(bool getActiveUserOnlyFlag)
        {
            var userIds = new List<int>();

            // get all active accounts. Assume that if account is disabled then users are inactive
            var accountIds = _accountService.GetAccountIds(getActiveUserOnlyFlag);

            foreach (var accountId in accountIds)
            {
                var accountUserList = GetListUserIdForAccount(accountId.ToString(), getActiveUserOnlyFlag);
                userIds.AddRange(accountUserList);
            }
            return userIds;
        }
    }
}
