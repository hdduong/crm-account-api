using System;
using System.Collections.Generic;
using System.Text;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Service.Models.Response;
using Crm.Api.Repository.Entities;

namespace Crm.Account.Api.Test.Service.Tests
{
    public class TestHelper
    {
        public static Api.Service.Models.Response.Account CreateAccount()
        {
            var account = new Api.Service.Models.Response.Account();
            account.AccountId = 2763;
            account.ParentAccountId = 2764;
            account.CompanyName = "Sample Mortgage A";
            account.Dba = "Sample Mortgage A";
            account.AccountName = "Sample A";
            account.Street1 = "3106 South Ws Young Dr. Bldg D, Ste. 402";
            account.Street2 = "";
            account.City = "Killeen";
            account.State = "TX";
            account.Zip = "76542";
            account.EncompassEnabled = 1;
            account.PremiumServicesEnabled = 1;

            return account;
        }

        public static List<Api.Service.Models.Response.Account> CreateAccounts()
        {
            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(CreateAccount());

            return accounts;
        }


        public static List<int> CreateAccountIds()
        {
            var accountIds = new List<int>();
            accountIds.Add(2763);
            return accountIds;
        }

        public static AccountDbO CreateAccountDbO()
        {
            var account = new AccountDbO();
            account.AccountId = 2763;
            account.ParentAccountId = 2764;
            account.CompanyName = "Sample Mortgage A";
            account.Dba = "Sample Mortgage A";
            account.AccountName = "Sample A";
            account.Street1 = "3106 South Ws Young Dr. Bldg D, Ste. 402";
            account.Street2 = "";
            account.City = "Killeen";
            account.State = "TX";
            account.Zip = "76542";

            return account;
        }

        public static RecordType CreateRecordType()
        {
            var recordType = new RecordType();
            recordType.Id = 19386;
            recordType.AccountId = 2763;
            recordType.Indicator = "C";
            recordType.Name = "Customers";
            recordType.Description = "Customers";
            recordType.IsPrimaryCustomerType = true;
            recordType.MrRecordType = 1;

            return recordType;
        }

        public static List<RecordType> CreateRecordTypes()
        {
            var recordTypes = new List<RecordType>();
            recordTypes.Add(CreateRecordType());
            return recordTypes;
        }

        public static List<int> CreateRecordTypeIds()
        {
            var recordTypes = new List<int>();
            recordTypes.Add(2763);
            return recordTypes;
        }

        public static RecordTypeDbO CreateRecordTypeDbO()
        {
            var recordType = new RecordTypeDbO();
            recordType.RecordTypeId = 19386;
            recordType.AccountId = 2763;
            recordType.RecordTypeIndicator = "C";
            recordType.RecordTypeName = "Customers";
            recordType.RecordTypeDesc = "Customers";
            recordType.IsPrimaryCustomerType = true;
            recordType.MrRecordType = 1;

            return recordType;
        }


        public static List<RecordTypeDbO> CreateRecordTypeDbOs()
        {
            var recordTypeDbOs = new List<RecordTypeDbO>();
            recordTypeDbOs.Add(CreateRecordTypeDbO());
            return recordTypeDbOs;
        }

        public static AccountUserDbO CreateAccountUserDbO()
        {
            var accountUserDbO = new AccountUserDbO();
            accountUserDbO.UserId = 2147335016;
            accountUserDbO.FirstName = "Jamie";
            accountUserDbO.LastName = "Crown";
            accountUserDbO.AccountId = 2763;
            return accountUserDbO;
        }

        public static List<AccountUserDbO> CreateAccountUserDbOs()
        {
            var accountUserDbOs = new List<AccountUserDbO>();
            accountUserDbOs.Add(CreateAccountUserDbO());
            return accountUserDbOs;
        }

        public static AccountUser CreateAccountUser()
        {
            var accountUserDbO = new AccountUser();
            accountUserDbO.UserId = 2147335016;
            accountUserDbO.FirstName = "Jamie";
            accountUserDbO.LastName = "Crown";
            accountUserDbO.AccountId = 2763;
            return accountUserDbO;
        }

        public static List<AccountUser> CreateAccountUsers()
        {
            var accountUsers = new List<AccountUser>();
            accountUsers.Add(CreateAccountUser());
            return accountUsers;
        }

        public static List<int> CreateUserIds()
        {
            var userIds = new List<int>();
            userIds.Add(2763);
            return userIds;
        }

        public static UserDbO CreateUserDbO()
        {
            var userDbO = new UserDbO();
            userDbO.UserId = 2147335016;
            userDbO.FirstName = "Jamie";
            userDbO.LastName = "Crown";
            userDbO.Email = "hien.duong@elliemae.com";
            userDbO.Business = "314-987-6543";
            userDbO.Mobile = "314-123-4567";
            userDbO.SiteAdmin = true;
            userDbO.MayEnterRates = true;
            userDbO.MayCreateTemplates = false;
            userDbO.MayViewOtherLoHotlists = false;
            userDbO.LoStreet = "1335 Strassner";
            userDbO.LoCity = "Saint Louis";
            userDbO.LoState = "MO";
            userDbO.LoZip = "63144";

            return userDbO;
        }

        public static User CreateUser()
        {
            var user = new User();
            user.UserId = 2147335016;
            user.FirstName = "Jamie";
            user.LastName = "Crown";
            user.Email = "hien.duong@elliemae.com";
            user.Business = "314-987-6543";
            user.Mobile = "314-123-4567";
            user.SiteAdmin = true;
            user.MayEnterRates = true;
            user.MayCreateTemplates = false;
            user.MayViewOtherLoHotlists = false;
            user.Street = "1335 Strassner";
            user.City = "Saint Louis";
            user.State = "MO";
            user.Zip = "63144";

            return user;
        }

        public static List<string> CreateLosUsernNames()
        {
            var losUsernames = new List<string>();
            losUsernames.Add("Jim Sample");
            return losUsernames;
        }

        public static AccountUserEntity CreateAccountUserEntity()
        {
            var accountUser = new AccountUserEntity();
            accountUser.MayCreateTemplates = true;
            accountUser.AccountId = 2763;
            accountUser.AccountUserId = 246112;
            accountUser.UserId = 2147335016;
            accountUser.MayEnterRates = true;
            accountUser.AccountAdmin = true;
            accountUser.MayViewOtherLoHotlists = false;
            return accountUser;
        }
    }

}

