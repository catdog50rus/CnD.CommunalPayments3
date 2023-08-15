using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Requests;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using CnD.CommunalPayments3.Domen.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.InvoiceEndpoints;

public class UpdateEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapPut("/api/invoices/update-invoice", Update);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateInvoiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult<UpdateInvoiceResponse>), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> Update(IMediator mediator, IMapper mapper, UpdateInvoiceRequest updateInvoice, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult<UpdateInvoiceResponse>();

        try
        {
            if(updateInvoice is null)
                return Results.Ok(response.ErrorResponseResult("Invoice пустой"));

            var invoice = mapper.Map<Invoice>(updateInvoice);

            var result = await mediator.Send(new UpdateInvoiceCommand(invoice), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult("Ошибка редактирования"));

            return Results.Ok(new ResponseResult<UpdateInvoiceResponse>()
            {
                Result = mapper.Map<UpdateInvoiceResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}