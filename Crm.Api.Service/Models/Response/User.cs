using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Service.Models.Response
{
    [ExcludeFromCodeCoverage]
    public class User
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Business { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string UserType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public DateTime? PasswordExpires { get; set; }
        public bool? ChangePasswordNextLogin { get; set; }
        public int? RedirectHotListSummaryNotifcation { get; set; }
        public bool? SiteAdmin { get; set; }
        public bool? WantsHotlistEmailNotification { get; set; }
        public string Title { get; set; }
        public int? RecordsPerPage { get; set; }
        public bool? PartialSiteAdmin { get; set; }
        public bool? ReceivesReports { get; set; }
        public bool? ProspectBetaUser { get; set; }
        public string PhotoFileName { get; set; }
        public string SignatureFileName { get; set; }
        public bool? MayEnterRates { get; set; }
        public bool? AccountAdmin { get; set; }
        public bool? MayCreateTemplates { get; set; }
        public bool? MayViewOtherLoHotlists { get; set; }
        public string BranchName { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LogoFile { get; set; }
        public string LicenseNumber { get; set; }
        public int? PremiumServicesEnabled { get; set; }
        public DateTime? TrialStartDate { get; set; }
        public DateTime? PremiumStopDate { get; set; }
        public List<string> LosUserNames { get; set; }
        public int? ViewOnlyMyNotes { get; set; }
        public bool? MayEnterSocialMediaLinks { get; set; }
        public string PersonalUrl { get; set; }
        public bool? LendingManager { get; set; }
        public bool? WantsHotlistEmailDetailNotification { get; set; }
        public int? RedirectHotlistEmailDetail { get; set; }
        public bool? WelcomeEmailSent { get; set; }
        public string EncompassUserName { get; set; }
        public bool? MayImportData { get; set; }
        public bool AutoAssignEnabled { get; set; }
    }
}
