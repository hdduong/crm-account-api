using System;
using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Repository.Entities
{
    [ExcludeFromCodeCoverage]
    public class RecordTypeDbO
    {
        public int RecordTypeId { get; set; }
        public int AccountId { get; set; }
        public string RecordTypeIndicator { get; set; }
        public string RecordTypeName { get; set; }
        public string RecordTypeDesc { get; set; }
        public DateTime RecordTypeDateCreated { get; set; }
        public string RecordTypeCreatedBy { get; set; }
        public DateTime? RecordTypeDateLastModified { get; set; }
        public string RecordTypeLastModifiedBy { get; set; }
        public string RecordTypeBackgroundColor { get; set; }
        public bool? RecordTypeRemoveEditAbility { get; set; }
        public bool RecordTypeUsePropertyAddress { get; set; }
        public bool? RecordTypeEditable { get; set; }
        public int? CopiedFromRecordTypeId { get; set; }
        public bool? IsPrimaryCustomerType { get; set; }
        public int? MrRecordType { get; set; }
    }
}
