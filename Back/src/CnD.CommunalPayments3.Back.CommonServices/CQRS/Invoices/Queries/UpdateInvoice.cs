using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record UpdateInvoiceCommand(Invoice Invoice) : IRequest<Invoice>;

public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, Invoice>
{
    public async Task<Invoice> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken = default)
    {
        var result = new Invoice
        {
            Id = request.Invoice.Id,
            Sum = new Sum(1300),
            Period = request.Invoice.Period,
            IsPaid = false
        };
        
        return await Task.FromResult(result);
    }
}