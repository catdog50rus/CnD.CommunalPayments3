using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Application;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.InvoiceEndpoints.GetAll;

public class GetAllEndpoint : AppDefinition
{
    //public override bool Exported { get; protected set; } = true;

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/invoices/get-invoices", GetAll);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<InvoiceGetAllResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> GetAll(IMediator mediator, IMapper mapper, HttpContext context)
    {
        try
        {
            var pagedListQueryParams = context.Request.Query.ParseToPages();

            var result = await mediator.Send(new GetAllInvoices(pagedListQueryParams, context.RequestAborted));

            if(result is null || !result.Any())
                return Results.Ok(new ResponseResult<List<InvoiceGetAllResponse>> { Result = new List<InvoiceGetAllResponse>() });

            var response = mapper.Map<List<InvoiceGetAllResponse>>(result);

            return Results.Ok(new ResponseResult<List<InvoiceGetAllResponse>> { Result = response });
        }
        catch (Exception ex)
        {
            return Results.Ok(new ResponseResult<List<InvoiceGetAllResponse>> { ErrorCode = 1, ErrorMessage = ex.Message});
        }
        
       
    }
}