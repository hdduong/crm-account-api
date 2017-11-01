using AutoMapper;
using Crm.Account.Api.Repository.Entities;
using Crm.Account.Api.Service.Models.Response;
using Crm.Api.Repository.Entities;

namespace Crm.Account.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDbO, Service.Models.Response.Account>()
                .ForMember(dest => dest.TargetedCampaignEnabled,
                    opttion => opttion.MapFrom(src => src.CampaignsEnabled))
                .ForMember(dest => dest.DataImportEnabled,
                    opttion => opttion.MapFrom(src => src.DataUploadEnabled))
                .ForMember(dest => dest.IsExactTargetUser,
                opttion => opttion.MapFrom(src => src.MassEmailPermission));
            CreateMap<UserDbO, User>()
                .ForMember(dest => dest.Title, opttion => opttion.MapFrom(src => src.UserTitle))
                .ForMember(dest => dest.Street, opttion => opttion.MapFrom(src => src.LoStreet))
                .ForMember(dest => dest.Street2, opttion => opttion.MapFrom(src => src.LoStreet2))
                .ForMember(dest => dest.City, opttion => opttion.MapFrom(src => src.LoCity))
                .ForMember(dest => dest.Zip, opttion => opttion.MapFrom(src => src.LoZip))
                .ForMember(dest => dest.State, opttion => opttion.MapFrom(src => src.LoState))
                .ForMember(dest => dest.LicenseNumber, opttion => opttion.MapFrom(src => src.UserLicenseNumber))
                .ForMember(dest => dest.WantsHotlistEmailNotification,
                    opttion => opttion.MapFrom(src => src.WantsEmailNotification))
                .ForMember(dest => dest.RedirectHotListSummaryNotifcation,
                    opttion => opttion.MapFrom(src => src.RedirectEmailHotList))
                .ForMember(dest => dest.WantsHotlistEmailDetailNotification,
                    opttion => opttion.MapFrom(src => src.HotlistNotificationDetail));
            CreateMap<RecordTypeDbO, RecordType>()
                .ForMember(dest => dest.Id, opttion => opttion.MapFrom(src => src.RecordTypeId))
                .ForMember(dest => dest.Indicator, opttion => opttion.MapFrom(src => src.RecordTypeIndicator))
                .ForMember(dest => dest.Name, opttion => opttion.MapFrom(src => src.RecordTypeName))
                .ForMember(dest => dest.Description, opttion => opttion.MapFrom(src => src.RecordTypeDesc))
                .ForMember(dest => dest.DateCreated, opttion => opttion.MapFrom(src => src.RecordTypeDateCreated))
                .ForMember(dest => dest.CreatedBy, opttion => opttion.MapFrom(src => src.RecordTypeCreatedBy))
                .ForMember(dest => dest.DateLastModified,
                    opttion => opttion.MapFrom(src => src.RecordTypeDateLastModified))
                .ForMember(dest => dest.LastModifiedBy, opttion => opttion.MapFrom(src => src.RecordTypeLastModifiedBy))
                .ForMember(dest => dest.BackgroundColor,
                    opttion => opttion.MapFrom(src => src.RecordTypeBackgroundColor))
                .ForMember(dest => dest.RemoveEditAbility,
                    opttion => opttion.MapFrom(src => src.RecordTypeRemoveEditAbility))
                .ForMember(dest => dest.Editable, opttion => opttion.MapFrom(src => src.RecordTypeEditable))
                .ForMember(dest => dest.UsePropertyAddress, opttion => opttion.MapFrom(src => src.RecordTypeUsePropertyAddress));
            CreateMap<AccountUserDbO, AccountUser>();
        }
    }
}

