using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Application;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Providers.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.ProviderEndpoints;

public class GetAllEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/providers/get-all", GetAll);base.ConfigureApplication(app);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<GetAllProvidersResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    [Authorize(Policy = "ApiKeyPolicy")]
    [FeatureGroupName("Providers")]
    private async Task<IResult> GetAll(IMediator mediator, IMapper mapper, HttpContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var pagedListQueryParams = context.Request.Query.ParseToPages();

            var result = await mediator.Send(new GetAllProvidersCommand(pagedListQueryParams), cancellationToken);

            if(result is null || !result.Any())
                return Results.Ok(new ResponseResult<List<GetAllProvidersResponse>> { Result = new List<GetAllProvidersResponse>() });

            var response = mapper.Map<List<GetAllProvidersResponse>>(result);

            return Results.Ok(new ResponseResult<List<GetAllProvidersResponse>> { Result = response });
        }
        catch (Exception ex)
        {
            return Results.Ok(new ResponseResult<List<GetAllProvidersResponse>> { ErrorCode = 1, ErrorMessage = ex.Message});
        }
    }
}