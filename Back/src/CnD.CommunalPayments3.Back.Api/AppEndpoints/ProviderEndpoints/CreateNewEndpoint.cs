using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Application;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.ProviderEndpoints;

public class CreateNewEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapPost("/api/providers/create", CreateNew);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<GetAllProvidersResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
// [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> CreateNew(IMediator mediator, IMapper mapper, CreateProviderRequest newItem, CancellationToken cancellationToken = default )
    {
        var response = new ResponseResult<CreateProviderResponse>();
        
        try
        {
            if (newItem is null)
                return Results.Ok(response.ErrorResponseResult("Provider пустой"));

            var item = mapper.Map<Provider>(newItem);

            var result = await mediator.Send(new CreateProviderCommand(item), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult("Ошибка создания"));

            return Results.Ok(new ResponseResult<CreateProviderResponse>
            {
                Result = mapper.Map<CreateProviderResponse>(result)
            });
            
        }
        catch (Exception ex)
        {
            return Results.Ok( new ResponseResult<CreateProviderResponse>().ErrorResponseResult(ex.Message));
        }
    }
}