using System;
using System.Collections.Generic;
using AutoMapper;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IShareService _shareService;
        private readonly IRecordTypeService _recordTypeService;
        private readonly IMapper _mapper;
        
        public AccountService(IShareService shareService, IAccountRepository accountRepository, IMapper mapper,
           IRecordTypeService recordTypeService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _shareService = shareService;
            _recordTypeService = recordTypeService;
        }

        public Models.Response.Account GetAccountById(string accountId)
        {
            var assertResult = _shareService.AssertAccountValid(accountId);

            // here means valid account (unsigned integer type and valid in db)
            var validAccountId = Int32.Parse(accountId);
            var accountDbO = _accountRepository.GetAccountById(validAccountId);
            var account = _mapper.Map<AccountDbO, Models.Response.Account>(accountDbO);
           
            var normalizedAccount = NormailizedOutputFields(account);
            return normalizedAccount;
        }

        public List<int> GetAccountIds(bool getOnlyActiveAccountFlag)
        {
            var accountIds = _accountRepository.GetAllAccountIds(getOnlyActiveAccountFlag);
            return accountIds;
        }

        public List<Models.Response.Account> GetAccountEntities(bool getOnlyActiveAccountFlag)
        {
            var accountEntities = _accountRepository.GetAccountEntities(getOnlyActiveAccountFlag);
            var accounts = _mapper.Map<List<AccountDbO>, List<Models.Response.Account>>(accountEntities);

            var normalizedAccounts = new List<Models.Response.Account>();
            foreach (var account in accounts)
            {
                var normalizedAccount = NormailizedOutputFields(account);
                normalizedAccounts.Add(normalizedAccount);
            }
            return normalizedAccounts;
        }

        public List<RecordType> GetRecordTypes(string accountId)
        {
            var assertValue = _shareService.AssertAccountValid(accountId);

            var recordTypes = _recordTypeService.GetListRecordTypeForAccountWithoutValidation(accountId);

            return recordTypes;
        }

        public List<int> GetRecordTypeIds(string accountId)
        {
            var assertValue = _shareService.AssertAccountValid(accountId);

            var recordTypes = _recordTypeService.GetListRecordTypeIdForAccountWithoutValidation(accountId);

            return recordTypes;
        }


        public RecordType GetRecordTypeByAccountIdAndId(string accountId, string recordTypeId)
        {
            var assertResult = _shareService.AssertAccountValid(accountId);
            assertResult = _shareService.AssertRecordTypeValid(recordTypeId);
            assertResult = _shareService.AssertAccountRecordTypeValid(accountId, recordTypeId);

            var recordType = _recordTypeService.GetRecordTypeByAccountIdAndIdWithoutValidation(accountId, recordTypeId);

            return recordType;
        }

        public Models.Response.Account NormailizedOutputFields(Models.Response.Account account)
        {
            var outputAccount = account;

            // LosName
            outputAccount.ClientLoanOriginationSystem = _shareService.GetLosNameById(account.EncompassEnabled);

            // PremiumServicesEnabled Null & 0: No; 1: Yes; 2: Per User
            if ((!account.PremiumServicesEnabled.HasValue) || (account.PremiumServicesEnabled == 0))
            {
                outputAccount.EnablePremiumService = ApiConstant.NoString;
            }
            else if (account.PremiumServicesEnabled == 1)
            {
                outputAccount.EnablePremiumService = ApiConstant.YesString;
            }
            else if (account.PremiumServicesEnabled == 2)
            {
                outputAccount.EnablePremiumService = ApiConstant.EnablePremiumServicePerUser;
            }

            return outputAccount;
        }
    }
}
