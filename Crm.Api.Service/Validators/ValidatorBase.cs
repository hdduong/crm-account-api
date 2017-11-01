using System.Linq;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Response;
using FluentValidation;

namespace Crm.Account.Api.Service.Validators
{
    public class ValidatorBase<TValidatingObject> : AbstractValidator<TValidatingObject>, IValidatorBase<TValidatingObject>
    {
        public MyValidationResult AssertValid(TValidatingObject item)
        {
            var myValidationResult = new MyValidationResult();
            var result = Validate(item);
            if (!result.IsValid)
            {
                myValidationResult.ErrorCode = result.Errors.ElementAt(0).ErrorCode;
                myValidationResult.IsValid = false;
                myValidationResult.ErrorMessage = result.Errors.ElementAt(0).ErrorMessage;
                myValidationResult.FluentFailures = result.Errors;
            }
            else
            {
                myValidationResult.IsValid = true;
            }
            return myValidationResult;
        }
    }
}
