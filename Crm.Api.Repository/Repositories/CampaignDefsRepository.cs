using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Dapper;

namespace Crm.Account.Api.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class CampaignDefsRepository
    {
        private readonly IDbConnectionFactory _dbConnection;

        public CampaignDefsRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public CampaignDefDbO GetCampaignDefById(int campaignDefId)
        {
            CampaignDefDbO campaignDefDbO;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                campaignDefDbO = connection.Query<CampaignDefDbO>(
                    "SELECT * FROM dbo.CampaignDefs WHERE CampaignDefId = @campaignDefId",
                    new { CampaignDefId = campaignDefId }).FirstOrDefault();
            }

            return campaignDefDbO;
        }
    }
}
