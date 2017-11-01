using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Crm.Account.Api.Service.Models.Response
{
    [ExcludeFromCodeCoverage]
    public class Account
    {
        public int AccountId { get; set; }
        public int ParentAccountId { get; set; }
        public string CompanyName { get; set; }
        public string Dba { get; set; }
        public string AccountName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? FireTriggers { get; set; }
        public bool? SendReports { get; set; }
        public string ReportFrequency { get; set; }
        public int? ReportDayOfWeek { get; set; }
        public int? ReportDayOfMonth { get; set; }
        public bool InternalAccount { get; set; }
        public string SpecialProcedures { get; set; }
        public bool AccountPastDue { get; set; }
        public int RecapturePeriod { get; set; }
        public int Version { get; set; }
        public bool IsExactTargetUser { get; set; }
        public string AccountLicenseNumber { get; set; }
        public string AccountEmailDisclosure { get; set; }
        public string AccountPrintDisclosure { get; set; }
        public bool? SolicitationEnabled { get; set; }
        public bool? FdicLogoEnabled { get; set; } // 0 or 1; Null: No
        public bool? EhlLogoEnabled { get; set; }
        public bool? EhoLogoEnabled { get; set; }
        public bool? NcuaLogoEnabled { get; set; }
        public bool? BbbLogoEnabled { get; set; }
        public bool? NoStandardTemplates { get; set; }
        public bool? NoStandardCampaigns { get; set; }
        public bool ExportToEncompassEnabled { get; set; }
        public bool MilestoneEnabled { get; set; }
        public bool UpdatesEnabled { get; set; }

        // EncompassEnabled will only contains intermidate result to get LosSystem name
        [JsonIgnore]
        public int EncompassEnabled { get; set; }
        public string ClientLoanOriginationSystem { get; set; }

        [JsonIgnore]
        public int? PremiumServicesEnabled { get; set; } // Null & 0: No; 1: Yes; 2: Per User
        public string EnablePremiumService { get; set; }
        public bool? TargetedCampaignEnabled { get; set; } // Null: No; 0: No; Others: True // in UI Enable Targeted Campaigns?
        public bool ProspectCampaignEnabled { get; set; } // Enable Auto-assign Prospect Campaign?	
        public int ProspectCampaignId { get; set; } // dbo.CampaignDefs Enable Auto-assign Prospect Campaign?	
        public bool ProspectFollowUpEnabled { get; set; }  // Enable Auto-assign Prospect Follow Up?	
        public int? ProspectFollowUpId { get; set; } // Enable Auto-assign Prospect Follow Up?	
        public bool? NewslettersEnabled { get; set; } // Null: No; 0: No; Others: True // Enable Recurring Campaigns? 
        public int? TrialPeriodLength { get; set; }
        public bool? MassEmailEnabled { get; set; } // Null: No; 0: No; Others: True
        public bool RestrictLoginByIp { get; set; } // 0 or 1      
        public bool? CustomSettings { get; set; } // 0 or 1; Null: No
        public int? SurveyProspectCampaignId { get; set; } // // dbo.CampaignDefs  Enable Survey Auto-assign Campaign?	
        public bool? BccEmailEnabled { get; set; }
        public string BccEmailAddress { get; set; }
        public bool? BccRecurringCampaignsEnabled { get; set; }
        public bool? BccBirthdayCampaignsEnabled { get; set; }
        public bool? BccTargetedCampaignsEnabled { get; set; }
        public bool? HtmlEditorEnabled { get; set; }
        public bool? UseDefaultRegZDisclosure { get; set; }
        public string AccountRegZDisclosure { get; set; }
        public string DefaultRegZDisclosure { get; set; }
        public bool? UseDefaultArmDisclosure { get; set; }
        public string AccountArmDisclosure { get; set; }
        public string DefaultArmDisclosure { get; set; }
        public bool? UseDefaultRegZDisclosureSpanish { get; set; }
        public string AccountRegZDisclosureSpanish { get; set; }
        public string DefaultRegZDisclosureSpanish { get; set; }
        public bool? UseLendingManagerUrl { get; set; }
        public string LendingManagerUrl { get; set; }
        public bool? CustomWelcomeEmailEnabled { get; set; }
        public int? CustomWelcomeEmailId { get; set; }
        public bool? CustomResetEmailEnabled { get; set; }
        public int? CustomResetEmailId { get; set; }
        public string HotlistContactsDefaultViewCode { get; set; } // Values from other table
        public bool MfaEnabled { get; set; }
        public int? ExactTargetAccountId { get; set; }
        public string PrivacyPolicyUrl { get; set; }
        public bool? UsePrivacyLinkUrl { get; set; }
        public bool SsoEnabled { get; set; }
        public bool AutoAssignEnabled { get; set; }
        public bool DataImportEnabled { get; set; }
    }
}
