using AutoMapper;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Responses;
using CnD.CommunalPayments3.Doman.Models;
using CnD.CommunalPayments3.Doman.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Back.Api.Models.Providers.AutomapperProfiles;

public class ApiProviderProfile : Profile
{
    public ApiProviderProfile()
    {
        #region Request

        CreateMap<CreateProviderRequest, Provider>()
            .ForMember(x => x.NameProvider, o => o.MapFrom(x => new ServiceName(x.NameProvider)))
            .ForMember(x => x.WebSite, o => o.MapFrom(x => new WebSite(x.WebSite)))
            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdateProviderRequest, Provider>()
            .ForMember(x => x.Id, o => o.MapFrom(x => new ModelId(x.Id)))
            .ForMember(x => x.NameProvider, o => o.MapFrom(x => new ServiceName(x.NameProvider)))
            .ForMember(x => x.WebSite, o => o.MapFrom(x => new WebSite(x.WebSite)))
            ;

        #endregion

        #region Response

        CreateMap<Provider, GetProviderResponse>()
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;
        
        CreateMap<Provider, GetAllProvidersResponse>()
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;

        CreateMap<Provider, UpdateProviderResponse>()
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;

        CreateMap<Provider, CreateProviderResponse>()
            .ForMember(dist => dist.Id,
                opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;

        #endregion
    }
}