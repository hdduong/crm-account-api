using Crm.Account.Api.Service.Models.Request;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Interfaces.Validators
{
    public interface IAccountRequestDsOValidator
    {
        MyValidationResult AssertValid(AccountGetRequestDsO item);
    }
}