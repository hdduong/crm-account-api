using System;
using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Repository.Entities
{
    [ExcludeFromCodeCoverage]
    public class CampaignDefDbO
    {
        public int CampaignDefId { get; set; }
        public int? CreatedFromDefId { get; set; }
        public int AccountId { get; set; }
        public string CampaignName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public int? CustomCampaign { get; set; }
        public bool? AccountDefault { get; set; }
        public bool AutomatedCampaign { get; set; }
        public int CampaignTimeValue { get; set; }
        public string CampaignTimeType { get; set; }
        public int CampaignTime { get; set; }
        public DateTime? CampaignStartTime { get; set; }
        public int? Occurrences { get; set; }
        public string CampaignType { get; set; }
    }
}
