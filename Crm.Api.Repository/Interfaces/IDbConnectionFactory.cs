using System.Data;

namespace Crm.Account.Api.Repository.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateMr4Connection();
    }
}