using System.Collections.Generic;
using FluentValidation.Results;

namespace Crm.Account.Api.Service.Models.Response
{
    public class MyValidationResult
    {
        public string ErrorCode { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<ValidationFailure> FluentFailures { get; set; }
    }
}
