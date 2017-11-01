namespace Crm.Account.Api.Service.Interfaces.Services
{
    public interface IEllieJwtService
    {
        bool Validate(string validingJwt, string encoded64Secret);
    }
}