using System.Collections.Generic;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Account.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get users
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     GET /api/users?accountId=2763
        /// </remarks>
        /// <param name="accountId">accountId</param>
        /// <param name="includeInactive">to include inactive users</param>
        /// <param name="view">view result by Id or Entity</param>
        /// <returns code="200">Account information</returns>
        /// <returns code="400">Bad Request</returns>
        /// <returns code="403">Forbidden</returns>
        /// <returns code="404">Not Found</returns>
        /// <returns code="500">Internal server error</returns>
        [ProducesResponseType(typeof(List<AccountUser>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        [HttpGet]
        public IActionResult GetUsers(string accountId, bool? includeInactive, ViewCategory view = ViewCategory.Id)
        {
            bool getActiveUserOnly = (includeInactive == null) || (!(bool)(includeInactive));
            if (string.IsNullOrEmpty(accountId)) // not passing accountId then return everything
            {
                if (view.Equals(ViewCategory.Id))
                {
                    return Ok(_userService.GetUserIds(getActiveUserOnly));
                }
                return Ok(_userService.GetUsers(getActiveUserOnly));
            }
            else
            {
                if (view.Equals(ViewCategory.Id))
                {
                    return Ok(_userService.GetListUserIdForAccount(accountId, getActiveUserOnly));
                }
                return Ok(_userService.GetListUsersForAccount(accountId, getActiveUserOnly));
            }

        }

        /// <summary>
        /// Get specific User by userId
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     GET /api/users/2147335016
        /// </remarks>
        /// <param name="id">userId</param>
        /// <returns code="200">Account information</returns>
        /// <returns code="400">Bad Request</returns>
        /// <returns code="403">Forbidden</returns>
        /// <returns code="404">Not Found</returns>
        /// <returns code="500">Internal server error</returns>
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userService.GetUserById(id);

            return Ok(user);
        }
    }
}