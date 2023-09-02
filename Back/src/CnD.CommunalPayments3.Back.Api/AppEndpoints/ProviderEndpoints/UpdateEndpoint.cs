using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.ProviderEndpoints;

public class UpdateEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapPut("/api/providers/update", Update);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateProviderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult<UpdateProviderResponse>), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> Update(IMediator mediator, IMapper mapper, UpdateProviderRequest updateProvider, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult<UpdateProviderResponse>();

        try
        {
            if(updateProvider is null)
                return Results.Ok(response.ErrorResponseResult("Provider пустой"));

            var provider = mapper.Map<Provider>(updateProvider);

            var result = await mediator.Send(new UpdateProviderCommand(provider), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult("Ошибка редактирования"));

            return Results.Ok(new ResponseResult<UpdateProviderResponse>()
            {
                Result = mapper.Map<UpdateProviderResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}