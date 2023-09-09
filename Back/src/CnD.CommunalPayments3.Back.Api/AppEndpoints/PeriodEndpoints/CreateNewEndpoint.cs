using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.PeriodEndpoints;

public class CreateNewEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapPost("/api/periods/create-period", CreateNew);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreatePeriodResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    [Authorize(Policy = "ApiKeyPolicy")]
    [FeatureGroupName("Periods")]
    private async Task<IResult> CreateNew(IMediator mediator, IMapper mapper, CreatePeriodRequest newItem, CancellationToken cancellationToken = default )
    {
        var response = new ResponseResult<CreatePeriodResponse>();
        
        try
        {
            if (newItem is null)
                return Results.Ok(response.ErrorResponseResult("Period пустой"));

            var item = mapper.Map<Period>(newItem);

            var result = await mediator.Send(new CreatePeriodCommand(item), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult("Ошибка создания"));

            return Results.Ok(new ResponseResult<CreatePeriodResponse>
            {
                Result = mapper.Map<CreatePeriodResponse>(result)
            });
            
        }
        catch (Exception ex)
        {
            return Results.Ok( new ResponseResult<CreatePeriodResponse>().ErrorResponseResult(ex.Message));
        }
    }
}