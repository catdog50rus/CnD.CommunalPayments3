using AutoMapper;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Doman.Models;
using CnD.CommunalPayments3.Doman.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Back.DataLayer.Infrastructure.MapperProfiles;

public class ProviderDbEntityProfile : Profile
{
    public ProviderDbEntityProfile()
    {
        CreateMap<Provider, ProviderEntity>()
            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.NameProvider, o => o.MapFrom(i => i.NameProvider.GetValue()))
            .ForPath(x => x.WebSite, o => o.MapFrom(i => i.WebSite.GetValue()))
            ;

        CreateMap<ProviderEntity, Provider>()
            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.NameProvider, o => o.MapFrom(i => new ServiceName(i.NameProvider)))
            .ForPath(x => x.WebSite, o => o.MapFrom(i => new WebSite(i.WebSite)))
            ;
    }
}