using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Controllers;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;
using Crm.Account.Api.Test.Service.Tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Crm.Account.Api.Test.Controller.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void GetAccounts_IncludeNull_ViewNull_Test()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountIds(It.IsAny<bool>())).Returns(TestHelper.CreateAccountIds);

            var accountController = new AccountController(accountServiceMock.Object);
            var result = accountController.GetAccounts(null, ViewCategory.Id);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<int>;
            Assert.AreEqual(okList.Count, 1);
        }

        [TestMethod]
        public void GetAccounts_IncludeTrue_ViewEntity_Test()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountEntities(It.IsAny<bool>())).Returns(TestHelper.CreateAccounts());

            var accountController = new AccountController(accountServiceMock.Object);
            var result = accountController.GetAccounts(true, ViewCategory.Entity);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<Api.Service.Models.Response.Account>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0).AccountId, 2763);
        }


        [TestMethod]
        public void GetAccount_Test()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetAccountById(It.IsAny<string>())).Returns(TestHelper.CreateAccount);

            var accountController = new AccountController(accountServiceMock.Object);
            var result = accountController.GetAccount(It.IsAny<string>());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as Api.Service.Models.Response.Account;
            Assert.AreEqual(okList.AccountId, 2763);
        }

        [TestMethod]
        public void GetRecordTypes_Id_Test()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetRecordTypeIds(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypeIds);

            var accountController = new AccountController(accountServiceMock.Object);
            var result = accountController.GetRecordTypes(It.IsAny<string>());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<int>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0), 2763);
        }

        [TestMethod]
        public void GetRecordTypes_Entity_Test()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetRecordTypes(It.IsAny<string>())).Returns(TestHelper.CreateRecordTypes());

            var accountController = new AccountController(accountServiceMock.Object);
            var result = accountController.GetRecordTypes(It.IsAny<string>(), ViewCategory.Entity);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<RecordType>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(okList.ElementAt(0).Id, 19386);
        }

        [TestMethod]
        public void GetRecordType_Test()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.Setup(x => x.GetRecordTypeByAccountIdAndId(It.IsAny<string>(), It.IsAny<string>())).Returns(TestHelper.CreateRecordType());

            var accountController = new AccountController(accountServiceMock.Object);
            var result = accountController.GetRecordType(It.IsAny<string>(), It.IsAny<string>());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as RecordType;
            Assert.AreEqual(okList.AccountId, 2763);
            Assert.AreEqual(okList.Id, 19386);
        }
    }
}
