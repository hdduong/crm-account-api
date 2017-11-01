using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Crm.Account.Api.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace Crm.Account.Api.Repository.Configuration
{
    [ExcludeFromCodeCoverage]
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly RepositoryConfiguration _repositoryConfiguration;

        public DbConnectionFactory(IOptions<RepositoryConfiguration> repositoryConfiguration)
        {
            _repositoryConfiguration = repositoryConfiguration.Value;
        }

        public IDbConnection CreateMr4Connection()
        {
            var conn = new SqlConnection(_repositoryConfiguration.MortgageReturns4Repository);
            conn.Open();
            return conn;
        }
    }

}
