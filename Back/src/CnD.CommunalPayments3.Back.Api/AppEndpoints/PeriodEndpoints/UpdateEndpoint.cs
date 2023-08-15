using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;
using CnD.CommunalPayments3.Domen.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.PeriodEndpoints;

public class UpdateEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapPut("/api/periods/update-period", Update);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdatePeriodResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult<UpdatePeriodResponse>), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Periods")]
    private async Task<IResult> Update(IMediator mediator, IMapper mapper, UpdatePeriodRequest updatePeriod, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult<UpdatePeriodResponse>();

        try
        {
            if(updatePeriod is null)
                return Results.Ok(response.ErrorResponseResult("Period пустой"));

            var period = mapper.Map<Period>(updatePeriod);

            var result = await mediator.Send(new UpdatePeriodCommand(period), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult("Ошибка редактирования"));

            return Results.Ok(new ResponseResult<UpdatePeriodResponse>()
            {
                Result = mapper.Map<UpdatePeriodResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}