using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.DataLayer.DI;

namespace CnD.CommunalPayments3.Back.Api.Definitions.UoW;

public class UoWDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddContext();
    }
}