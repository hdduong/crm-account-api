using Crm.Account.Api.Service.Models.Request;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Interfaces.Validators
{
    public interface IUserRequestDsOValidator
    {
        MyValidationResult AssertValid(UserGetRequestDsO item);
    }
}