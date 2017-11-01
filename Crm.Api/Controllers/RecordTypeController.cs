using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Api.Service.Interfaces.Services;
using Crm.Api.Service.Models.Response;
using Crm.Api.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/recordType")]
    public class RecordTypeController : Controller
    {
        private readonly IRecordTypeService _recordTypeService;

        public RecordTypeController(IRecordTypeService recordTypeService)
        {
            _recordTypeService = recordTypeService;
        }

        /// <summary>
        /// Get specific recordType by recordTypeId
        /// </summary>
        /// <remarks>
        /// Sample request
        ///     GET /api/recordType/12
        /// </remarks>
        /// <param name="recordTypeId"></param>
        /// <returns code="200">Account information</returns>
        /// <returns code="400">Bad Request</returns>
        /// <returns code="401">UnAuthorized</returns>
        /// <returns code="404">Not Found</returns>
        /// <returns code="500">Internal server error</returns>
        [ProducesResponseType(typeof(RecordType), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        [HttpGet("{recordTypeId}")]
        public IActionResult GetRecordTypeId(string recordTypeId)
        {
            var recordType = _recordTypeService.GetRecordTypeById(recordTypeId);

            return Ok(recordType);
        }
    }
}