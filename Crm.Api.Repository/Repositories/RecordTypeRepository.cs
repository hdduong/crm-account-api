using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Dapper;

namespace Crm.Account.Api.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RecordTypeRepository : IRecordTypeRepository
    {
        private readonly IDbConnectionFactory _dbConnection;

        public RecordTypeRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<RecordTypeDbO> GetRecordTypeByAccountId(int accountId)
        {
            List<RecordTypeDbO> recordTypeDbOs;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                recordTypeDbOs = connection.Query<RecordTypeDbO>(
                    "SELECT * FROM dbo.RecordType WHERE AccountId = @accountId",
                    new { AccountId = accountId }).ToList();
            }

            return recordTypeDbOs;
        }

        public RecordTypeDbO GetRecordTypeById(int recordTypeId)
        {
            RecordTypeDbO recordTypeDbOs;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                recordTypeDbOs = connection.Query<RecordTypeDbO>(
                    "SELECT * FROM dbo.RecordType WHERE RecordTypeId = @recordTypeId",
                    new {RecordTypeId = recordTypeId}).FirstOrDefault();
            }

            return recordTypeDbOs;
        }

        public RecordTypeDbO GetRecordTypeByAccountIdAndId(int accountId, int recordTypeId)
        {
            RecordTypeDbO recordTypeDbOs;

            using (IDbConnection connection = _dbConnection.CreateMr4Connection())
            {
                recordTypeDbOs = connection.Query<RecordTypeDbO>(
                    "SELECT * FROM dbo.RecordType WHERE AccountId = @accountId And RecordTypeId = @recordTypeId",
                    new { AccountId = accountId, RecordTypeId = recordTypeId }).FirstOrDefault();
            }

            return recordTypeDbOs;
        }
    }

}
