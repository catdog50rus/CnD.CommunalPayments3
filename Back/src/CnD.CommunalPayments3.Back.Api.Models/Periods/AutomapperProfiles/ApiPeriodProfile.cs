using AutoMapper;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;
using CnD.CommunalPayments3.Domen.Helpers;
using CnD.CommunalPayments3.Domen.Models;

namespace CnD.CommunalPayments3.Back.Api.Models.Periods.AutomapperProfiles;

public class ApiPeriodProfile : Profile
{
    public ApiPeriodProfile()
    {
        #region Response

        CreateMap<Period, CreatePeriodResponse>()
            .ForMember(dist => dist.Month,
                opt => opt.MapFrom(i => i.Month.GetShortName()))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;

        CreateMap<Period, UpdatePeriodResponse>()
            .ForMember(dist => dist.Month,
                opt => opt.MapFrom(i => i.Month.GetShortName()))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;

        CreateMap<Period, GetPeriodResponse>()
            .ForMember(dist => dist.Month,
                opt => opt.MapFrom(i => i.Month.GetShortName()))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;
        
        CreateMap<Period, GetAllPeriodsResponse>()
            .ForMember(dist => dist.Month,
                opt => opt.MapFrom(i => i.Month.GetShortName()))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;

        #endregion

        #region Request

        CreateMap<CreatePeriodRequest, Period>()
            .ForMember(x => x.Month, o => o.MapFrom(x => EnumHelper.GetValueFromDescr<MonthName>(x.Month)))
            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdatePeriodRequest, Period>()
            .ForMember(x => x.Month, o => o.MapFrom(x => EnumHelper.GetValueFromDescr<MonthName>(x.Month)));

        #endregion
    }
}