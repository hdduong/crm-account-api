using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Service.Exception
{
    [ExcludeFromCodeCoverage]
    public class MyAuthorizationException : System.Exception
    {
        public string ErrorCode { get; set; }

        public MyAuthorizationException() { }

        public MyAuthorizationException(string message) : base(message)
        {
        }

        public MyAuthorizationException(string message, string errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public MyAuthorizationException(string message, string errorCode, System.Exception innerException) : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        public MyAuthorizationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
