using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Exception;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Request;

namespace Crm.Account.Api.Service.Services
{
    public class ShareService : IShareService
    {
        private readonly IAccountRequestDsOValidator _accountValidator;
        private readonly IUserRequestDsOValidator _userValidator;
        private readonly IAccountUserRequestDsoValidator _accountUserValidator;
        private readonly IRecordTypeRequestDsOValidator _recordTypeValidator;
        private readonly IAccountRecordTypeDsOValidator _accountRecordTypeValidator;
        private readonly ILosRepository _losRepository;

        public ShareService(IAccountRequestDsOValidator accountValidator, IUserRequestDsOValidator userValidator, IAccountUserRequestDsoValidator accountUserValidator,
            IRecordTypeRequestDsOValidator recordTypeValidator, IAccountRecordTypeDsOValidator accountRecordTypeValidator, ILosRepository losRepository)
        {
            _accountValidator = accountValidator;
            _userValidator = userValidator;
            _accountUserValidator = accountUserValidator;
            _recordTypeValidator = recordTypeValidator;
            _accountRecordTypeValidator = accountRecordTypeValidator;
            _losRepository = losRepository;
        }

        public bool AssertAccountValid(string accountId)
        {
            var requestAccountModel = new AccountGetRequestDsO(accountId);

            var requestValidationResult = _accountValidator.AssertValid(requestAccountModel);
            if (!requestValidationResult.IsValid)
            {
                throw new MyInvalidException(requestValidationResult.ErrorMessage, requestValidationResult.ErrorCode, new System.Exception(requestValidationResult.FluentFailures.ToString()));
            }         

            return true;
        }


        public bool AssertUserValid(string userId)
        {
            var requestUserModel = new UserGetRequestDsO(userId);

            var requestValidationResult = _userValidator.AssertValid(requestUserModel);
            if (!requestValidationResult.IsValid)
            {
                throw new MyInvalidException(requestValidationResult.ErrorMessage, requestValidationResult.ErrorCode, new System.Exception(requestValidationResult.FluentFailures.ToString()));
            }

            return true;
        }

        public bool AssertRecordTypeValid(string recordTypeId)
        {
            var requestRecordTypeModel = new RecordTypeGetRequestDsO(recordTypeId);

            var requestValidationResult = _recordTypeValidator.AssertValid(requestRecordTypeModel);
            if (!requestValidationResult.IsValid)
            {
                throw new MyInvalidException(requestValidationResult.ErrorMessage, requestValidationResult.ErrorCode, new System.Exception(requestValidationResult.FluentFailures.ToString()));
            }

            return true;
        }

        public bool AssertAccountRecordTypeValid(string accountId, string recordTypeId)
        {
            var requestRecordTypeModel = new AccountRecordTypeGetRequestDsO(accountId, recordTypeId);

            var requestValidationResult = _accountRecordTypeValidator.AssertValid(requestRecordTypeModel);
            if (!requestValidationResult.IsValid)
            {
                throw new MyInvalidException(requestValidationResult.ErrorMessage, requestValidationResult.ErrorCode, new System.Exception(requestValidationResult.FluentFailures.ToString()));
            }

            return true;
        }

        public string GetLosNameById(int losId)
        {
            var los = _losRepository.GetLosById(losId);
            if (los == null) return "";

            return los.LosName;
        }
    }
}
