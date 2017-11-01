using System;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Request;
using FluentValidation;

namespace Crm.Account.Api.Service.Validators
{
    public class RecordTypeRequestDsOValidator : ValidatorBase<RecordTypeGetRequestDsO>, IRecordTypeRequestDsOValidator
    {
        private readonly IRecordTypeRepository _recordTypeRepository;

        public RecordTypeRequestDsOValidator(IRecordTypeRepository recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;

            RuleFor(p => p.RecordTypeId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must(RecordTypeIdMustBeIntType).WithErrorCode(ErrorCodeCategory.CrmInvalidInput.ToString()).WithMessage(InvalidRecordTypeErrorMessage)
                .Must(RecordTypeIdBiggerThanZero).WithErrorCode(ErrorCodeCategory.CrmInvalidInput.ToString()).WithMessage(InvalidRecordTypeLessEqualZeroErrorMessage)
                .Must(RecordTypeMustExist).WithErrorCode(ErrorCodeCategory.CrmNotFound.ToString()).WithMessage(RecordTypeNotFoundErrorMessage);
        }

        private bool RecordTypeIdMustBeIntType(string inputRecordTypeId)
        {
            return Int32.TryParse(inputRecordTypeId, out _);
        }

        private string InvalidRecordTypeErrorMessage(RecordTypeGetRequestDsO recordTypeDsO)
        {
            return string.Format(ErrorMessage.InvalidRecordType, recordTypeDsO.RecordTypeId);
        }

        private bool RecordTypeIdBiggerThanZero(string inputRecordTypeId)
        {
            int recordTypeId = Int32.Parse(inputRecordTypeId);
            if (recordTypeId <= 0)
                return false;

            return true;
        }

        private string InvalidRecordTypeLessEqualZeroErrorMessage(RecordTypeGetRequestDsO recordTypeDsO)
        {
            return string.Format(ErrorMessage.InvalidRecordTypeValue, recordTypeDsO.RecordTypeId);
        }

        private bool RecordTypeMustExist(string inputRecordTypeId)
        {
            int recordTypeId = Int32.Parse(inputRecordTypeId);
            var recordType = _recordTypeRepository.GetRecordTypeById(recordTypeId);
            return recordType != null;
        }

        private string RecordTypeNotFoundErrorMessage(RecordTypeGetRequestDsO recordTypeDsO)
        {
            return string.Format(ErrorMessage.RecordTypeNotExists, recordTypeDsO.RecordTypeId);
        }
    }
}
