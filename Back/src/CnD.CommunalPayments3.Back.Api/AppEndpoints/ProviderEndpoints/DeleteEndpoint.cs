using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.ProviderEndpoints;

public class DeleteEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapDelete("/api/providers/delete/{id:int}", Delete);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> Delete(IMediator mediator, int id, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult();

        try
        {
            if (id <= 0)
                return Results.Ok(response.ErrorResponseResult($"Не валидный ID: {id}"));

            await mediator.Publish(new DeleteProviderCommand(id), cancellationToken);

            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}