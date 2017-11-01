using System;
using System.Collections.Generic;
using AutoMapper;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Models.Response;

namespace Crm.Account.Api.Service.Services
{
    public class RecordTypeService : IRecordTypeService
    {
        private readonly IRecordTypeRepository _recordTypeRepository;
        private readonly IMapper _mapper;
        private readonly IShareService _shareService;

        public RecordTypeService(IRecordTypeRepository recordTypeRepository, IMapper mapper, IShareService shareService)
        {
            _recordTypeRepository = recordTypeRepository;
            _mapper = mapper;
            _shareService = shareService;
        }

        public List<RecordType> GetListRecordTypeForAccountWithoutValidation(string accountId)
        {
            // here means valid account (unsigned integer type and valid in db)
            var validAccountId = Int32.Parse(accountId);
            var recordTypeDbOs = _recordTypeRepository.GetRecordTypeByAccountId(validAccountId);
            var recordTypes = _mapper.Map<List<RecordTypeDbO>, List<RecordType>>(recordTypeDbOs);

            return recordTypes;
        }

        public List<int> GetListRecordTypeIdForAccountWithoutValidation(string accountId)
        {
            // here means valid account (unsigned integer type and valid in db)
            var validAccountId = Int32.Parse(accountId);
            var recordTypeDbOs = _recordTypeRepository.GetRecordTypeByAccountId(validAccountId);

            var recordTypeIds = new List<int>();
            foreach (var recordTypeDbO in recordTypeDbOs)
            {
                recordTypeIds.Add(recordTypeDbO.RecordTypeId);
            }

            return recordTypeIds;
        }


        public RecordType GetRecordTypeByIdWithoutValidation(string recordTypeId)
        {
            // here means valid userId (unsigned integer type and valid in db)
            var validRecordTypeId = Int32.Parse(recordTypeId);
            var recordTypeDbO = _recordTypeRepository.GetRecordTypeById(validRecordTypeId);
            var recordType = _mapper.Map<RecordTypeDbO, RecordType>(recordTypeDbO);

            return recordType;
        }

        public RecordType GetRecordTypeByAccountIdAndIdWithoutValidation(string accountId, string recordTypeId)
        {
            // here means valid userId (unsigned integer type and valid in db)
            var validAccountId = Int32.Parse(accountId);
            var validRecordTypeId = Int32.Parse(recordTypeId);
            var recordTypeDbO = _recordTypeRepository.GetRecordTypeByAccountIdAndId(validAccountId, validRecordTypeId);
            var recordType = _mapper.Map<RecordTypeDbO, RecordType>(recordTypeDbO);

            return recordType;
        }

        public RecordType GetRecordTypeById(string recordTypeId)
        {
            var result = _shareService.AssertRecordTypeValid(recordTypeId);

            return GetRecordTypeByIdWithoutValidation(recordTypeId);
        }
    }
}
