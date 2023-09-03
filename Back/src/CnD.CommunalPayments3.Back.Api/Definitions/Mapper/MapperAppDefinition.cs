using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;

namespace CnD.CommunalPayments3.Back.Api.Definitions.Mapper;

public class MapperAppDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddMaps(typeof(Models.AssemblyRunner));
            mc.AddMaps(typeof(DataLayer.Infrastructure.AssemblyRunner));
        });

        var mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}