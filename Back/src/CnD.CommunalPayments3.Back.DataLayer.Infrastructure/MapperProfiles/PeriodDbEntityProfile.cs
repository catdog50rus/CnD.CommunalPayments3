using AutoMapper;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Helpers;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Back.DataLayer.Infrastructure.MapperProfiles;

public class PeriodDbEntityProfile : Profile
{
    public PeriodDbEntityProfile()
    {
        CreateMap<Period, PeriodEntity>()
            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Month, o => o.MapFrom(i => i.Month.GetShortName()))
            .ForPath(x => x.Year, o => o.MapFrom(i => i.Year))
            ;

        CreateMap<PeriodEntity, Period>()
            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Month, o => o.MapFrom(i => EnumHelper.GetValueFromDescr<MonthName>(i.Month)))
            .ForPath(x => x.Year, o => o.MapFrom(i => i.Year))
            ;
    }
}