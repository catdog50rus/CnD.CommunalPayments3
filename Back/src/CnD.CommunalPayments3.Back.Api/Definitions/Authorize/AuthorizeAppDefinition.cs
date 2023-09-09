using Calabonga.AspNetCore.AppDefinitions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CnD.CommunalPayments3.Back.Api.Definitions.Authorize;

public class AuthorizeAppDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();
        
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiKeyPolicy", policy =>
            {
                policy.AddAuthenticationSchemes(new[] { JwtBearerDefaults.AuthenticationScheme });
                policy.Requirements.Add(new ApiKeyRequirement());
            });
        });
        
        builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
        builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}