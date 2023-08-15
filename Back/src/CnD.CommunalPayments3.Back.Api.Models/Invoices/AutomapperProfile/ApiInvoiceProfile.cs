using AutoMapper;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Responses;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Back.Api.Models.Invoices.AutomapperProfile;

public class ApiInvoiceProfile : Profile
{
    public ApiInvoiceProfile()
    {
        #region Responses

        CreateMap<Invoice, GetAllInvoiceResponse>()
            .ForMember(dist => dist.ProviderId,
            opt => opt.MapFrom(i => i.Provider.Id.Value))
            .ForMember(dist => dist.PeriodId,
             opt => opt.MapFrom(i => i.Period.Id.Value))
            .ForMember(dist => dist.Sum,
                opt => opt.MapFrom(i => i.Sum.Value))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;
        
        CreateMap<Invoice, GetInvoiceResponse>()
            .ForMember(dist => dist.ProviderId,
            opt => opt.MapFrom(i => i.Provider.Id.Value))
            .ForMember(dist => dist.PeriodId,
             opt => opt.MapFrom(i => i.Period.Id.Value))
            .ForMember(dist => dist.Sum,
                opt => opt.MapFrom(i => i.Sum.Value))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;
        
        CreateMap<Invoice, CreateInvoiceResponse>()
             .ForMember(dist => dist.ProviderId,
                 opt => opt.MapFrom(i => i.Provider.Id.Value))
            .ForMember(dist => dist.PeriodId,
                 opt => opt.MapFrom(i => i.Period.Id.Value))
            .ForMember(dist => dist.Sum,
                opt => opt.MapFrom(i => i.Sum.Value))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;

        CreateMap<Invoice, UpdateInvoiceResponse>()
            .ForMember(dist => dist.ProviderId,
                 opt => opt.MapFrom(i => i.Provider.Id.Value))
            .ForMember(dist => dist.PeriodId,
                 opt => opt.MapFrom(i => i.Period.Id.Value))
            .ForMember(dist => dist.Sum,
                opt => opt.MapFrom(i => i.Sum.Value))
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.Value))
            ;


        #endregion
        
        #region Requests

        CreateMap<CreateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider { Id = new ModelId(i.ProviderId) }))
            
            .ForPath(x => x.Period, o => o.MapFrom(i => new Period { Id = new ModelId(i.PeriodId) }))

            .ForPath(x => x.Id, o => o.Ignore())

            .ForPath(x => x.IsPaid, o => o.Ignore())
            ;

        CreateMap<UpdateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider { Id = new ModelId(i.ProviderId) }))
            
            .ForPath(x => x.Period, o => o.MapFrom(i => new Period { Id = new ModelId(i.PeriodId) }))
            ;

        #endregion
    }
}