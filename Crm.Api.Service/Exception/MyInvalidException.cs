
using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Service.Exception
{
    [ExcludeFromCodeCoverage]
    public class MyInvalidException : System.Exception
    {
        public string ErrorCode { get; set; }

        public MyInvalidException() { }

        public MyInvalidException(string message) : base (message)
        {
        }

        public MyInvalidException(string message, string errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public MyInvalidException(string message, string errorCode, System.Exception innerException) : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        public MyInvalidException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
