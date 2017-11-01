namespace Crm.Account.Api.Constant
{
    public class ErrorMessage
    {
        public const string InternalServerError = "Internal Server Error";
        public const string InvalidInputSummary = "Invalid input parameter";
        public const string NotFoundInputSummary = "Input Not Found";

        public const string InvalidAccountType = "'{0}' is invalid value. AccountId must be valid integer";
        public const string InvalidUserType = "'{0}' is invalid value. UserId must be valid integer";
        public const string InvalidRecordType = "'{0}' is invalid value. RecordTypeId must be valid integer";

        public const string InvalidAccountValue = "'{0}' is invalid value. AccountId must be bigger than 0";
        public const string InvalidUserValue = "'{0}' is invalid value. UserId must be bigger than 0";
        public const string InvalidRecordTypeValue = "'{0}' is invalid value. RecordTypeId must be bigger than 0";


        public const string AccountNotExists = "'AccountId '{0}' does not exist";
        public const string UserNotExists = "'UserId '{0}' does not exist";
        public const string RecordTypeNotExists = "'RecordTypeId '{0}' does not exist";
        public const string AccountUserNotExists = "'UserId '{0}' with AccountId '{1}' does not exist";
        public const string AccountRecordTypeNotExists = "'RecordTypeId '{0}' with AccountId '{1}' does not exist";

        public const string JwtExpired = "Jwt is already expired";
        public const string JwtInvalid = "Invalid Jwt";
        public const string JwtUnexpectedException = "Unexpected exception while verifying Jwt";
        public const string JwtEmpty = "Jwt could not be empty or blank";
    }
}
