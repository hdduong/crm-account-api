using System;
using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Service.Models.Response
{
    [ExcludeFromCodeCoverage]
    public class RecordType
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Indicator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateLastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string BackgroundColor { get; set; }
        public bool? RemoveEditAbility { get; set; }
        public bool UsePropertyAddress { get; set; }
        public bool? Editable { get; set; }
        public int? CopiedFromRecordTypeId { get; set; }
        public bool? IsPrimaryCustomerType { get; set; }
        public int? MrRecordType { get; set; }
    }
}
