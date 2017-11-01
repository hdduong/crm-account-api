using System;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Request;
using FluentValidation;

namespace Crm.Account.Api.Service.Validators
{
    public class UserRequestDsOValidator : ValidatorBase<UserGetRequestDsO>, IUserRequestDsOValidator
    {
        private readonly IUserRepository _userRepository;

        public UserRequestDsOValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.UserId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must(UserIdMustBeIntType).WithErrorCode(ErrorCodeCategory.CrmInvalidInput.ToString()).WithMessage(InvalidUserErrorMessage)
                .Must(UserIdBiggerThanZero).WithErrorCode(ErrorCodeCategory.CrmInvalidInput.ToString()).WithMessage(InvalidUserLessEqualZeroErrorMessage)
                .Must(UserMustExist).WithErrorCode(ErrorCodeCategory.CrmNotFound.ToString()).WithMessage(UserNotFoundErrorMessage);
        }

        private bool UserIdMustBeIntType(string inputUserId)
        {
            return Int32.TryParse(inputUserId, out _);
        }

        private string InvalidUserErrorMessage(UserGetRequestDsO userDso)
        {
            return string.Format(ErrorMessage.InvalidUserType, userDso.UserId);
        }

        private bool UserIdBiggerThanZero(string inputUserId)
        {
            int userId = Int32.Parse(inputUserId);
            if (userId <= 0)
                return false;

            return true;
        }

        private string InvalidUserLessEqualZeroErrorMessage(UserGetRequestDsO userDsO)
        {
            return string.Format(ErrorMessage.InvalidUserValue, userDsO.UserId);
        }

        private bool UserMustExist(string inputUserId)
        {
            int userId = Int32.Parse(inputUserId);
            return _userRepository.CheckUserExistsByUserId(userId);
        }

        private string UserNotFoundErrorMessage(UserGetRequestDsO userDsO)
        {
            return string.Format(ErrorMessage.UserNotExists, userDsO.UserId);
        }
    }
}
