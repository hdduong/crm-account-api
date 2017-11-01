namespace Crm.Account.Api.Service.Models.Request
{
    public class UserGetRequestDsO
    {
        public UserGetRequestDsO(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}
