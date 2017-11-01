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
    public class UserControllerTests
    {
        [TestMethod]
        public void GetUsers_NullAccountId_ViewId_Test()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetUserIds(It.IsAny<bool>())).Returns(TestHelper.CreateUserIds);

            var userController = new UserController(userServiceMock.Object);
            var result = userController.GetUsers("",It.IsAny<bool>());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<int>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0), 2763);            
        }

        [TestMethod]
        public void GetUsers_NullAccountId_ViewEntity_Test()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetUsers(It.IsAny<bool>())).Returns(TestHelper.CreateAccountUsers);

            var userController = new UserController(userServiceMock.Object);
            var result = userController.GetUsers("", It.IsAny<bool>(), ViewCategory.Entity);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<AccountUser>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(okList.ElementAt(0).UserId, 2147335016);
        }

        [TestMethod]
        public void GetUsers_NotNullAccountId_ViewId_Test()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetListUserIdForAccount("2763", It.IsAny<bool>())).Returns(TestHelper.CreateUserIds);

            var userController = new UserController(userServiceMock.Object);
            var result = userController.GetUsers("2763", It.IsAny<bool>());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<int>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0), 2763);
        }

        [TestMethod]
        public void GetUsers_NotNullAccountId_ViewEntities_Test()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetListUsersForAccount("2763", It.IsAny<bool>())).Returns(TestHelper.CreateAccountUsers);

            var userController = new UserController(userServiceMock.Object);
            var result = userController.GetUsers("2763", It.IsAny<bool>(), ViewCategory.Entity);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as List<AccountUser>;
            Assert.AreEqual(okList.Count, 1);
            Assert.AreEqual(okList.ElementAt(0).AccountId, 2763);
            Assert.AreEqual(okList.ElementAt(0).UserId, 2147335016);
        }

        [TestMethod]
        public void GetUser_Test()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(TestHelper.CreateUser);

            var userController = new UserController(userServiceMock.Object);
            var result = userController.GetUser(It.IsAny<string>());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var okList = okResult.Value as User;
            Assert.AreEqual(okList.FirstName, "Jamie");
            Assert.AreEqual(okList.UserId, 2147335016);
        }
    }
}
