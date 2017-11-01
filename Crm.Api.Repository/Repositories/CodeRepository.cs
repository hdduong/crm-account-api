using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Dapper;

namespace Crm.Account.Api.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class CodeRepository
    {
        private readonly IDbConnectionFactory _dbConnection;

        public CodeRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public CodeDbO GetCodeById(int codeId)
        {
            CodeDbO codeDbo;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                codeDbo = connection.Query<CodeDbO>(
                    "SELECT * FROM dbo.Codes WHERE CodeID = @codeId",
                    new { CodeID = codeId }).FirstOrDefault();
            }

            return codeDbo;
        }
    }
}
