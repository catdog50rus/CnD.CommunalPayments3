using Calabonga.AspNetCore.AppDefinitions;

namespace CnD.CommunalPayments3.Back.Api.Defenitions.Common;

public class CommonAppDefinition : AppDefinition
{
    /// <summary>
    /// Configure application for current microservice
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public override void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env)
        => app.UseHttpsRedirection();

    /// <summary>
    /// Configure services for current microservice
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalization();
        services.AddHttpContextAccessor();
        services.AddResponseCaching();
        services.AddMemoryCache();
        //services.AddDiContainer();
    }
}