using System;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Request;
using FluentValidation;

namespace Crm.Account.Api.Service.Validators
{
    public class AccountRecordTypeDsOValidator : ValidatorBase<AccountRecordTypeGetRequestDsO>, IAccountRecordTypeDsOValidator
    {
        private readonly IRecordTypeRepository _recordTypeRepository;

        public AccountRecordTypeDsOValidator(IRecordTypeRepository recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
            RuleFor(p => p)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must(RecordTypeMustExist).WithErrorCode(ErrorCodeCategory.CrmNotFound.ToString()).WithMessage(AccountRecordTypeNotFoundErrorMessage);
        }



        private bool RecordTypeMustExist(AccountRecordTypeGetRequestDsO accountRecordTypeDsO)
        {
            // assume that ran valid userId and accountId check
            int accountId = Int32.Parse(accountRecordTypeDsO.AccountId);
            int recordTypeId = Int32.Parse(accountRecordTypeDsO.RecordTypeId);

            var recordType = _recordTypeRepository.GetRecordTypeByAccountIdAndId(accountId, recordTypeId);
            return recordType != null;
        }

        private string AccountRecordTypeNotFoundErrorMessage(AccountRecordTypeGetRequestDsO accountRecordTypeDsO)
        {
            return string.Format(ErrorMessage.AccountRecordTypeNotExists, accountRecordTypeDsO.RecordTypeId, accountRecordTypeDsO.AccountId);
        }


    }
}
