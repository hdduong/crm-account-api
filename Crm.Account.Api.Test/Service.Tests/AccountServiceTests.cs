using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Exception;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Services;
using Crm.Account.Api.Service.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.Frameworks;

namespace Crm.Account.Api.Test.Service.Tests
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void AccountById_AccountIdNull_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();

            var shareService = new ShareService(accountValidator, userValidator,accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountById(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void AccountById_AccountNotIntType_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountById("bacd");
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void AccountById_AccountLessThan0_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountById("-1");
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void AccountById_AccountMustExist_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(false);
            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountById("27634");
        }


        [TestMethod]
        public void AccountById_AccoutValidAccount_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO{LosName = "Encompass"});

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());


            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountById("2763");
            Assert.AreEqual(result.AccountId, 2763);
            Assert.AreEqual(result.ClientLoanOriginationSystem, "Encompass");
            Assert.AreEqual(result.EnablePremiumService, "Yes");
        }

        [TestMethod]
        public void AccountByIds_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountIds.Add(2764);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());


            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountIds(true);
            Assert.AreEqual(result.Count, accountIds.Count);
            Assert.AreEqual(result.ElementAt(0), accountIds.ElementAt(0));
        }

        [TestMethod]
        public void GetAccountEntities_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetAccountEntities(true);
            Assert.AreEqual(result.Count, accountIds.Count);
            Assert.AreEqual(result.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(result.ElementAt(0).ClientLoanOriginationSystem, "Encompass");
            Assert.AreEqual(result.ElementAt(0).EnablePremiumService, "Yes");
        }


        [TestMethod]
        public void GetRecordTypes_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypes());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypes("2763");
            Assert.AreEqual(result.Count, accountIds.Count);
            Assert.AreEqual(result.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(result.ElementAt(0).Indicator, "C");
            Assert.AreEqual(result.ElementAt(0).Description, "Customers");
        }


        [TestMethod]
        public void GetRecordTypeIds_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeIds("2763");
            Assert.AreEqual(result.Count, accountIds.Count);
            Assert.AreEqual(result.ElementAt(0), 2763);

        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeByAccountIdAndId_RecordTypeId_NullEmpty()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeByAccountIdAndId(It.IsAny<string>(), string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeByAccountIdAndId_RecordTypeId_NotInteger()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeByAccountIdAndId(It.IsAny<string>(), "abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeByAccountIdAndId_RecordTypeId_LessThan0()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeByAccountIdAndId(It.IsAny<string>(), "-1");
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeByAccountIdAndId_RecordTypeId_IdNotExist()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>())).Returns((RecordTypeDbO)null);

            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeByAccountIdAndId(It.IsAny<string>(), "27634");
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeByAccountIdAndId_RecordTypeId_IdExistsButNotInAccount()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>())).Returns(TestHelper.CreateRecordTypeDbO());
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>())).Returns((RecordTypeDbO)null);

            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeByAccountIdAndId(It.IsAny<string>(), "27634");
        }

        [TestMethod]      
        public void GetRecordTypeByAccountIdAndId_ValidRecordTypeIdAndAccountId()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);
            var accountIds = new List<int>();
            accountIds.Add(2763);
            accountRepositoryMock.Setup(x => x.GetAllAccountIds(It.IsAny<bool>())).Returns(accountIds);

            var accountEntities = new List<AccountDbO>();
            accountEntities.Add(TestHelper.CreateAccountDbO());
            accountRepositoryMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(accountEntities);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>())).Returns(TestHelper.CreateRecordTypeDbO());
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>())).Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();
            losRepository.Setup(x => x.GetLosById(It.IsAny<int>())).Returns(new LosDbO { LosName = "Encompass" });

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var recordTypeServiceMock = new Mock<IRecordTypeService>();
            recordTypeServiceMock.Setup(x => x.GetListRecordTypeIdForAccountWithoutValidation(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds());
            recordTypeServiceMock.Setup(x => x.GetRecordTypeByAccountIdAndIdWithoutValidation(It.IsAny<string>(), It.IsAny<string>())).Returns(TestHelper.CreateRecordType());
            
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AccountDbO, Api.Service.Models.Response.Account>(It.IsAny<AccountDbO>()))
                .Returns(TestHelper.CreateAccount());
            mockMapper.Setup(x => x.Map<RecordTypeDbO, Api.Service.Models.Response.RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType());

            var accounts = new List<Api.Service.Models.Response.Account>();
            accounts.Add(TestHelper.CreateAccount());

            mockMapper.Setup(x => x.Map<List<AccountDbO>, List<Api.Service.Models.Response.Account>>(It.IsAny<List<AccountDbO>>()))
                .Returns(accounts);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountService = new AccountService(shareService, accountRepositoryMock.Object, mockMapper.Object,
                recordTypeServiceMock.Object);

            var result = accountService.GetRecordTypeByAccountIdAndId("2763", "19386");
            Assert.AreEqual(result.AccountId, 2763);
            Assert.AreEqual(result.Indicator, "C");
        }
    }
}
