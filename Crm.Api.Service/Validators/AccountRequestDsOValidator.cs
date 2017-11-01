using System;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Request;
using FluentValidation;

namespace Crm.Account.Api.Service.Validators
{
    public class AccountRequestDsOValidator : ValidatorBase<AccountGetRequestDsO>, IAccountRequestDsOValidator
    {
        private readonly IAccountRepository _accountRepository;

        public AccountRequestDsOValidator(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            RuleFor(p => p.AccountId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must(AccountIdMustBeIntType).WithErrorCode(ErrorCodeCategory.CrmInvalidInput.ToString()).WithMessage(InvalidAccountErrorMessage)
                .Must(AccountIdBiggerThanZero).WithErrorCode(ErrorCodeCategory.CrmInvalidInput.ToString()).WithMessage(InvalidAccountLessEqualZeroErrorMessage)
                .Must(AccountMustExist).WithErrorCode(ErrorCodeCategory.CrmNotFound.ToString()).WithMessage(AccountNotFoundErrorMessage);
        }

        private bool AccountIdMustBeIntType(string inputAccountId)
        {
            return Int32.TryParse(inputAccountId, out _);
        }

        private string InvalidAccountErrorMessage(AccountGetRequestDsO accountDso)
        {
            return string.Format(ErrorMessage.InvalidAccountType, accountDso.AccountId);
        }

        private bool AccountIdBiggerThanZero(string inputAccountId)
        {
            int accountId = Int32.Parse(inputAccountId);
            if (accountId <= 0)
                return false;

            return true;
        }

        private string InvalidAccountLessEqualZeroErrorMessage(AccountGetRequestDsO accountDso)
        {
            return string.Format(ErrorMessage.InvalidAccountValue, accountDso.AccountId);
        }

        private bool AccountMustExist(string inputAccountId)
        {
            int accountId = Int32.Parse(inputAccountId);
            return _accountRepository.CheckAccountExistsByAcountId(accountId);
        }

        private string AccountNotFoundErrorMessage(AccountGetRequestDsO accountDso)
        {
            return string.Format(ErrorMessage.AccountNotExists, accountDso.AccountId);
        }
    }
}
