using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.AutomapperProfile;
using CnD.CommunalPayments3.Back.Services.CommonServices;

namespace CnD.CommunalPayments3.Back.Api.Definitions.Mapper;

public class MapperAppDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddMaps(typeof(Models.AssemblyRunner));
            mc.AddMaps(typeof(CnD.CommunalPayments3.Back.DataLayer.Infrastructure.AssemblyRunner));
        });

        var mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}