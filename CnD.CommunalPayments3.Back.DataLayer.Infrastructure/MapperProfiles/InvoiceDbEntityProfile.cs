using AutoMapper;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Helpers;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Back.DataLayer.Infrastructure.MapperProfiles.Invoices;

public class InvoiceDbEntityProfile : Profile
{
    public InvoiceDbEntityProfile()
    {
        CreateMap<Invoice, InvoiceEntity>()
            .ForPath(x => x.PeriodId, o => o.MapFrom(i => i.Period.Id.Value))
            .ForPath(x => x.Period, o => o.Ignore())
    
            .ForPath(x => x.ProviderId, o => o.MapFrom(i => i.Provider.Id.Value))
            .ForPath(x => x.Provider, o => o.Ignore())

            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Sum, o => o.MapFrom(i => i.Sum.Value))
            .ForPath(x => x.IsPaid, o => o.MapFrom(i=>i.IsPaid))
            //.ForPath(x => x.UpdatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;


        CreateMap<InvoiceEntity, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider
            {
                Id = new ModelId(i.ProviderId),
                NameProvider = new ServiceName(i.Provider.NameProvider),
                WebSite = new WebSite(i.Provider.WebSite),
            }))

            .ForPath(x => x.Period, o => o.MapFrom(i => new Period
            {
                Id = new ModelId(i.PeriodId),
                Month = EnumHelper.GetValueFromDescr<MonthName>(i.Period.Month),
                Year = i.Period.Year,
            }))

            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Sum, o => o.MapFrom(i => new Sum(i.Sum)))

            ;
    }
}