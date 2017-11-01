using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Exception;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;
using Crm.Account.Api.Service.Services;
using Crm.Account.Api.Service.Validators;
using Crm.Api.Repository.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Crm.Account.Api.Test.Service.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void GetUserIds_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());

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

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);

            var result = userService.GetUserIds(It.IsAny<bool>());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.ElementAt(0), 2147335016);
        }

        [TestMethod]
        public void GetUsers_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);

            var result = userService.GetUsers(It.IsAny<bool>());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(result.ElementAt(0).UserId, 2147335016);
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetUserById_NullUserId_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);
            var result = userService.GetUserById(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetUserById_UserIdNotInteger_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);
            var result = userService.GetUserById("abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetUserById_UserIdNotExists_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());
            userRepositoryMock.Setup(x => x.CheckUserExistsByUserId(It.IsAny<int>()))
                .Returns(false);

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);
            var result = userService.GetUserById("2147335016");
        }

        [TestMethod]
        public void GetUserById_ValidUserId()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());
            userRepositoryMock.Setup(x => x.CheckUserExistsByUserId(It.IsAny<int>()))
                .Returns(true);
            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(TestHelper.CreateUserDbO);
            userRepositoryMock.Setup(x => x.GetLosUserNames(It.IsAny<int>())).Returns(TestHelper.CreateLosUsernNames);
            userRepositoryMock.Setup(x => x.GetAcountUserEntity(It.IsAny<int>())).Returns(TestHelper.CreateAccountUserEntity);

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());
            mockMapper.Setup(x => x.Map<UserDbO, User>(It.IsAny<UserDbO>()))
                .Returns(TestHelper.CreateUser);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);
            var result = userService.GetUserById("2147335016");

            Assert.AreEqual(result.UserId, 2147335016);
            Assert.AreEqual(result.AccountAdmin, null);
            Assert.AreEqual(result.LosUserNames.Count, 1);
            Assert.AreEqual(result.MayEnterRates, true);
            Assert.AreEqual(result.MayViewOtherLoHotlists, false);
        }


        [TestMethod]
        public void GetListUsersForAccount_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());
            userRepositoryMock.Setup(x => x.CheckUserExistsByUserId(It.IsAny<int>()))
                .Returns(true);
            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(TestHelper.CreateUserDbO);
            userRepositoryMock.Setup(x => x.GetLosUserNames(It.IsAny<int>())).Returns(TestHelper.CreateLosUsernNames);
            userRepositoryMock.Setup(x => x.GetAcountUserEntity(It.IsAny<int>())).Returns(TestHelper.CreateAccountUserEntity);

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());
            mockMapper.Setup(x => x.Map<UserDbO, User>(It.IsAny<UserDbO>()))
                .Returns(TestHelper.CreateUser);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);
            var result = userService.GetListUsersForAccount("2763", It.IsAny<bool>());

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(result.ElementAt(0).UserId, 2147335016);
        }


        [TestMethod]
        public void GetUserByAccountIdAndIdWithoutValidation_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByAccountId(It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(TestHelper.CreateAccountUserDbOs());
            userRepositoryMock.Setup(x => x.CheckUserExistsByUserId(It.IsAny<int>()))
                .Returns(true);
            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(TestHelper.CreateUserDbO);
            userRepositoryMock.Setup(x => x.GetLosUserNames(It.IsAny<int>())).Returns(TestHelper.CreateLosUsernNames);
            userRepositoryMock.Setup(x => x.GetAcountUserEntity(It.IsAny<int>())).Returns(TestHelper.CreateAccountUserEntity);

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
            mockMapper.Setup(x => x.Map<List<AccountUserDbO>, List<AccountUser>>(It.IsAny<List<AccountUserDbO>>()))
                .Returns(TestHelper.CreateAccountUsers());
            mockMapper.Setup(x => x.Map<UserDbO, User>(It.IsAny<UserDbO>()))
                .Returns(TestHelper.CreateUser);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds());

            var userService = new UserService(userRepositoryMock.Object, mockMapper.Object, shareService, accountServiceMock.Object);
            var result = userService.GetUserByAccountIdAndIdWithoutValidation("2763", "2147335016");

            Assert.AreEqual(result.FirstName, "Jamie");
            Assert.AreEqual(result.LastName, "Crown");
            Assert.AreEqual(result.Email, "hien.duong@elliemae.com");
            Assert.AreEqual(result.Business, "314-987-6543");
            Assert.AreEqual(result.UserId, 2147335016);
        }

    }
}
