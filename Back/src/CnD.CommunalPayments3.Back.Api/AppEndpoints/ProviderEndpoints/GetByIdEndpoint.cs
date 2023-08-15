using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.ProviderEndpoints;

public class GetByIdEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/providers/get/{id:int}", GetById);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<GetProviderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> GetById(IMediator mediator, IMapper mapper, int id, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult<GetProviderResponse>();
        
        try
        {
            if (id <= 0)
                return Results.Ok(response.ErrorResponseResult($"Не валидный ID: {id}"));

            var result = await mediator.Send(new GetProviderCommand(id), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult($"Запись с ID: {id} не найдена"));

            return Results.Ok(new ResponseResult<GetProviderResponse>
            {
                Result = mapper.Map<GetProviderResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}