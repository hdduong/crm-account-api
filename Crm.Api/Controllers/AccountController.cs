using System.Collections.Generic;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Account.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Get accounts.
        /// </summary>
        /// <param name="includeInactive">to include inactive accounts</param >
        /// <param name="view">Get accounts by id or entity. By default is id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Service.Models.Response.Account>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult GetAccounts(bool? includeInactive, ViewCategory view = ViewCategory.Id)
        {
            bool getActiveAccountOnly = (includeInactive == null) || (!(bool)(includeInactive));
            if (view.Equals(ViewCategory.Id))
            {
                return Ok(_accountService.GetAccountIds(getActiveAccountOnly));
            }
            return Ok(_accountService.GetAccountEntities(getActiveAccountOnly));
        }

        /// <summary>
        /// Get specific account information by accountId
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     GET /api/account/2763
        /// </remarks>
        /// <param name="id">accountId</param>
        /// <returns code="200">Account information</returns>
        /// <returns code="400">Bad Request</returns>
        /// <returns code="403">Forbidden</returns>
        /// <returns code="404">Not Found</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Service.Models.Response.Account), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult GetAccount(string id)
        {
            var account = _accountService.GetAccountById(id);

            return Ok(account);
        }

        /// <summary>
        /// Get all record type for specific account by accountId
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     GET /api/account/2763/recordTypes
        /// </remarks>
        /// <param name="id">accountId</param>
        /// <param name="view">Get accounts by id or entity. By default is id</param>
        /// <returns code="200">Account information</returns>
        /// <returns code="400">Bad Request</returns>
        /// <returns code="403">Forbidden</returns>
        /// <returns code="404">Not Found</returns>
        /// <returns code="500">Internal server error</returns>
        [ProducesResponseType(typeof(List<RecordType>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        [HttpGet("{id}/recordTypes")]
        public IActionResult GetRecordTypes(string id, ViewCategory view = ViewCategory.Id)
        {
            if (view.Equals(ViewCategory.Id))
            {
                return Ok(_accountService.GetRecordTypeIds(id));
            }
            return Ok(_accountService.GetRecordTypes(id));
        }


        /// <summary>
        /// Get specific recordType by accountId and recordTypeId
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     GET /api/account/2763/recordTypes/12
        /// </remarks>
        /// <param name="id">accountId</param>
        /// <param name="rId">recordTypeId</param>
        /// <returns code="200">Account information</returns>
        /// <returns code="400">Bad Request</returns>
        /// <returns code="403">Forbidden</returns>
        /// <returns code="404">Not Found</returns>
        /// <returns code="500">Internal server error</returns>
        [ProducesResponseType(typeof(RecordType), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        [HttpGet("{id}/recordTypes/{rId}")]
        public IActionResult GetRecordType(string id, string rId)
        {
            var recordTypes = _accountService.GetRecordTypeByAccountIdAndId(id, rId);

            return Ok(recordTypes);
        }
    }
}