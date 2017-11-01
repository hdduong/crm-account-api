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
    public class RecordTypeServiceTests
    {
        [TestMethod]
        public void GetListRecordTypeIdForAccountWithoutValidation_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountId(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbOs);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result = recordTypeService.GetListRecordTypeIdForAccountWithoutValidation("2763");

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.ElementAt(0), 19386);
        }

        [TestMethod]
        public void GetListRecordTypeForAccountWithoutValidation_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountId(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbOs);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result = recordTypeService.GetListRecordTypeForAccountWithoutValidation("2763");

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.ElementAt(0).Id, 19386);
            Assert.AreEqual(result.ElementAt(0).Indicator, "C");
            Assert.AreEqual(result.ElementAt(0).Name, "Customers");
            Assert.AreEqual(result.ElementAt(0).Description, "Customers");
        }

        [TestMethod]
        public void GetRecordTypeByIdWithoutValidation_Test()
        {
            // shared service
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);
            mockMapper.Setup(x => x.Map<RecordTypeDbO, RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result = recordTypeService.GetRecordTypeByIdWithoutValidation("2763");

            Assert.AreEqual(result.Id, 19386);
            Assert.AreEqual(result.Indicator, "C");
            Assert.AreEqual(result.Name, "Customers");
            Assert.AreEqual(result.Description, "Customers");
        }


        [TestMethod]
        public void GetRecordTypeByAccountIdAndIdWithoutValidation_Test()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);
            mockMapper.Setup(x => x.Map<RecordTypeDbO, RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result =
                recordTypeService.GetRecordTypeByAccountIdAndIdWithoutValidation("2763", "19386");

            Assert.AreEqual(result.Id, 19386);
            Assert.AreEqual(result.Indicator, "C");
            Assert.AreEqual(result.Name, "Customers");
            Assert.AreEqual(result.Description, "Customers");

        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeById_NullRecordTypeId()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);
            mockMapper.Setup(x => x.Map<RecordTypeDbO, RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result =
                recordTypeService.GetRecordTypeById(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeById_RecordTypeIdNotInt()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);
            mockMapper.Setup(x => x.Map<RecordTypeDbO, RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result =
                recordTypeService.GetRecordTypeById("abcd");
        }


        [TestMethod]
        [ExpectedException(typeof(MyInvalidException))]
        public void GetRecordTypeById_RecordTypeLessThan0()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);
            mockMapper.Setup(x => x.Map<RecordTypeDbO, RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result =
                recordTypeService.GetRecordTypeById("-1");
        }

        [TestMethod]
        public void GetRecordTypeById_Valid()
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.CheckAccountExistsByAcountId(It.IsAny<int>())).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            var recordTypeRepositoryMock = new Mock<IRecordTypeRepository>();
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeById(It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);
            recordTypeRepositoryMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(TestHelper.CreateRecordTypeDbO);

            var losRepository = new Mock<ILosRepository>();

            // shared service
            var accountValidator = new AccountRequestDsOValidator(accountRepositoryMock.Object);
            var userValidator = new UserRequestDsOValidator(userRepositoryMock.Object);
            var accountUserValidator = new AccountUserRequestDsoValidator(userRepositoryMock.Object);
            var recordTypeRequestDsOValidator = new RecordTypeRequestDsOValidator(recordTypeRepositoryMock.Object);
            var accountRecordTypeDsOValidator = new AccountRecordTypeDsOValidator(recordTypeRepositoryMock.Object);

            // account Service
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<RecordTypeDbO>, List<RecordType>>(It.IsAny<List<RecordTypeDbO>>()))
                .Returns(TestHelper.CreateRecordTypes);
            mockMapper.Setup(x => x.Map<RecordTypeDbO, RecordType>(It.IsAny<RecordTypeDbO>()))
                .Returns(TestHelper.CreateRecordType);

            var shareService = new ShareService(accountValidator, userValidator, accountUserValidator, recordTypeRequestDsOValidator, accountRecordTypeDsOValidator, losRepository.Object);

            var recordTypeService = new RecordTypeService(recordTypeRepositoryMock.Object, mockMapper.Object, shareService);
            var result =
                recordTypeService.GetRecordTypeById("19386");

            Assert.AreEqual(result.Id, 19386);
            Assert.AreEqual(result.Indicator, "C");
            Assert.AreEqual(result.Name, "Customers");
            Assert.AreEqual(result.Description, "Customers");
        }
    }
}
