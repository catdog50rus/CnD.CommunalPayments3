using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.InvoiceEndpoints;

public class CreateNewEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapPost("/api/invoices/create-invoice", CreateNew);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateInvoiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    [Authorize(Policy = "ApiKeyPolicy")]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> CreateNew(IMediator mediator, IMapper mapper, CreateInvoiceRequest newInvoice, CancellationToken cancellationToken = default )
    {
        var response = new ResponseResult<CreateInvoiceResponse>();
        
        try
        {
            if (newInvoice is null)
                return Results.Ok(response.ErrorResponseResult("Invoice пустой"));
        
            var invoice = mapper.Map<Invoice>(newInvoice);

            var result = await mediator.Send(new CreateInvoiceCommand(invoice), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult("Ошибка создания"));

            return Results.Ok( new ResponseResult<CreateInvoiceResponse>
            {
                Result = mapper.Map<CreateInvoiceResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok( new ResponseResult<CreateInvoiceResponse>().ErrorResponseResult(ex.Message));
        }
    }
}