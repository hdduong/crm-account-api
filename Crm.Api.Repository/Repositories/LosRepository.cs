using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Dapper;

namespace Crm.Account.Api.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class LosRepository : ILosRepository
    {

        private readonly IDbConnectionFactory _dbConnection;

        public LosRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public LosDbO GetLosById(int losId)
        {
            LosDbO losDbo;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                losDbo = connection.Query<LosDbO>(
                    "SELECT * FROM dbo.LOS WHERE LosId = @losId",
                    new { LosId = losId }).FirstOrDefault();
            }

            return losDbo;
        }
    }
}
