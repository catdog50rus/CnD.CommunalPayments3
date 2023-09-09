using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Application;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.PeriodEndpoints;

public class GetAllEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/periods/get-periods", GetAll);base.ConfigureApplication(app);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<GetAllPeriodsResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    [Authorize(Policy = "ApiKeyPolicy")]
    [FeatureGroupName("Periods")]
    private async Task<IResult> GetAll(IMediator mediator, IMapper mapper, HttpContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var pagedListQueryParams = context.Request.Query.ParseToPages();

            var result = await mediator.Send(new GetAllPeriodsCommand(pagedListQueryParams), cancellationToken);

            if(result is null || !result.Any())
                return Results.Ok(new ResponseResult<List<GetAllPeriodsResponse>> { Result = new List<GetAllPeriodsResponse>() });

            var response = mapper.Map<List<GetAllPeriodsResponse>>(result);

            return Results.Ok(new ResponseResult<List<GetAllPeriodsResponse>> { Result = response });
        }
        catch (Exception ex)
        {
            return Results.Ok(new ResponseResult<List<GetAllPeriodsResponse>> { ErrorCode = 1, ErrorMessage = ex.Message});
        }
    }
}