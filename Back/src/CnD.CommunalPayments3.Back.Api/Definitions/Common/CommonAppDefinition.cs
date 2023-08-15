using Calabonga.AspNetCore.AppDefinitions;

namespace CnD.CommunalPayments3.Back.Api.Definitions.Common;

public class CommonAppDefinition : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.UseHttpsRedirection();
    }

    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCaching();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddLocalization();
        builder.Services.AddMemoryCache();
    }
}