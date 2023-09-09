using AutoMapper;
using Calabonga.AspNetCore.AppDefinitions;
using CnD.CommunalPayments3.Back.Api.Models.Base;
using CnD.CommunalPayments3.Back.Api.Models.Base.Response;
using CnD.CommunalPayments3.Back.Api.Models.Invoices.Responses;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments3.Back.Api.AppEndpoints.InvoiceEndpoints;

public class GetByIdEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/invoices/get-invoice/{id:int}", GetById);
    }
    
    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<GetInvoiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    [Authorize(Policy = "ApiKeyPolicy")]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> GetById(IMediator mediator, IMapper mapper, int id, CancellationToken cancellationToken = default)
    {
        var response = new ResponseResult<GetInvoiceResponse>();
        
        try
        {
            if (id <= 0)
                return Results.Ok(response.ErrorResponseResult($"Не валидный ID: {id}"));

            var result = await mediator.Send(new GetInvoiceCommand(id), cancellationToken);

            if (result is null)
                return Results.Ok(response.ErrorResponseResult($"Запись с ID: {id} не найдена"));

            return Results.Ok(new ResponseResult<GetInvoiceResponse>
            {
                Result = mapper.Map<GetInvoiceResponse>(result)
            });
        }
        catch (Exception ex)
        {
            return Results.Ok(response.ErrorResponseResult(ex.Message));
        }
    }
}