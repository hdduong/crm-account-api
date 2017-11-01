using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Repository.Entities
{
    [ExcludeFromCodeCoverage]
    public class AccountUserDbO
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string LastLogin { get; set; }
        public string Email { get; set; }
        public bool WelcomeEmailSent { get; set; }
    }
}
