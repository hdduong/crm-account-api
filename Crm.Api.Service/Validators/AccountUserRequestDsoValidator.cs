using System;
using System.Diagnostics.CodeAnalysis;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Request;
using FluentValidation;

namespace Crm.Account.Api.Service.Validators
{
    [ExcludeFromCodeCoverage]
    public class AccountUserRequestDsoValidator : ValidatorBase<AccountUserGetRequestDsO>, IAccountUserRequestDsoValidator
    {
        private readonly IUserRepository _userRepository;

        public AccountUserRequestDsoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(p => p)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must(UserMustExist).WithErrorCode(ErrorCodeCategory.CrmNotFound.ToString()).WithMessage(AccountUserNotFoundErrorMessage);
        }

        private bool UserMustExist(AccountUserGetRequestDsO accountUserDsO)
        {
            // assume that ran valid userId and accountId check
            int accountId = Int32.Parse(accountUserDsO.AccountId);
            int userId = Int32.Parse(accountUserDsO.UserId);

            var user = _userRepository.GetUserByAccountIdAndId(accountId, userId);
            return user != null;
        }

        private string AccountUserNotFoundErrorMessage(AccountUserGetRequestDsO userDsO)
        {
            return string.Format(ErrorMessage.UserNotExists, userDsO.UserId, userDsO.AccountId);
        }

    }
}
