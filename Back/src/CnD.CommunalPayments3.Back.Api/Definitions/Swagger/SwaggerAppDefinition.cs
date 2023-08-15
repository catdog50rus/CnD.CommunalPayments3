using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Application;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace CnD.CommunalPayments3.Back.Api.Definitions.Swagger;

public class SwaggerAppDefinition : AppDefinition
{
    private const string AppTitle = "Communal Payment - 3.0 API";
    private const string SwaggerConfig = "/swagger/v1/swagger.json";
    
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = AppTitle,
            });

            options.ResolveConflictingActions(x => x.First());

            options.TagActionsBy(api =>
            {
                string tag;
                if (api.ActionDescriptor is { } descriptor)
                {
                    var attribute = descriptor.EndpointMetadata.OfType<FeatureGroupNameAttribute>().FirstOrDefault();
                    tag = attribute?.GroupName ?? descriptor.RouteValues["controller"] ?? "Untitled";
                }
                else
                {
                    tag = api.RelativePath!;
                }

                var tags = new List<string>();
                if (!string.IsNullOrEmpty(tag))
                {
                    tags.Add(tag);
                }
                return tags;
            });

            var url = builder.Configuration.GetSection("AuthServer").GetValue<string>("Url");

            /*options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{url}/connect/authorize", UriKind.Absolute),
                        TokenUrl = new Uri($"{url}/connect/token", UriKind.Absolute),
                        Scopes = new Dictionary<string, string>
                        {
                            { "api", "Default scope" }
                        }
                    }
                }
            });*/
            /*options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });*/
        });
    }

    public override void ConfigureApplication(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        app.UseSwagger();
        app.UseSwaggerUI(settings =>
        {
            settings.SwaggerEndpoint(SwaggerConfig, AppTitle);
            settings.DocumentTitle = AppTitle;
            settings.DefaultModelExpandDepth(0);
            // settings.DefaultModelRendering(ModelRendering.Model);
            // settings.DefaultModelsExpandDepth(0);
            // settings.DocExpansion(DocExpansion.None);
            // settings.OAuthScopeSeparator(" ");
            // settings.OAuthClientId("client-id-code");
            // settings.OAuthClientSecret("client-secret-code");
            // settings.DisplayRequestDuration();
            //settings.OAuthAppName(AppData.ServiceName);
        });
    }
}