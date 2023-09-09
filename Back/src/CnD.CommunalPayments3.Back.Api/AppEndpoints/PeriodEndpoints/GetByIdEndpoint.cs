using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.PeriodEndpoints;

public class GetByIdEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/periods/get-period/{id:int}", GetById);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<GetPeriodResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    [Authorize(Policy = "ApiKeyPolicy")]
    [FeatureGroupName("Periods")]
    private async Task<IResult> GetById(IMediator mediator, IMapper mapper, int id, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult<GetPeriodResponse>();
        
        try
        {
            if (id <= 0)
                return Results.Ok(response.ErrorResponseResult($"Не валидный ID: {id}"));

            var result = await mediator.Send(new GetPeriodCommand(id), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult($"Запись с ID: {id} не найдена"));

            return Results.Ok(new ResponseResult<GetPeriodResponse>
            {
                Result = mapper.Map<GetPeriodResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}