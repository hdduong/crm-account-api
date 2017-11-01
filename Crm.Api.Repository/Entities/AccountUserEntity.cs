using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Repository.Entities
{
    /// <summary>
    /// Map to dbo.AccountUser table under MortgageReturns4
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AccountUserEntity
    {
        public int AccountUserId { get; set; }
        public int? AccountId { get; set; }
        public int? UserId { get; set; }
        public bool? PriorityAccount { get; set; }
        public bool? IsTeamLeader { get; set; }
        public int MyTeamLeader { get; set; }
        public bool? AccountAdmin { get; set; }
        public bool? MayEnterRates { get; set; }
        public bool? MayCreateTemplates { get; set; }
        public bool? MayViewOtherLoHotlists { get; set; }
        public bool? MayViewExcelIcon { get; set; }
        public int Access { get; set; }
        public bool? RunReports { get; set; }
        public bool? ApproveNewsletters { get; set; }
        public bool? RecordTypeAdmin { get; set; }
        public bool? ChangeRecordTypes { get; set; }
        public int? HotlistViewId { get; set; }
        public int? ContactViewId { get; set; }
        public bool? DataImportEnabled { get; set; }
    }
}
