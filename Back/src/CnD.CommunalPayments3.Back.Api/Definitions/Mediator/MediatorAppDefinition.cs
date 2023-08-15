using System.Reflection;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Application;
using MediatR;

namespace CnD.CommunalPayments3.Back.Api.Definitions.Mediator;

public class MediatorAppDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        builder.Services.AddMediatR(config=>config.RegisterServicesFromAssembly(typeof(CnD.CommunalPayments3.Back.Services.CommonServices.AssemblyRunner).Assembly));
    }
}