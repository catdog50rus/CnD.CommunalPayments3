using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record GetInvoiceCommand(int Id) : IRequest<Invoice>;

public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceCommand, Invoice>
{
    public async Task<Invoice> Handle(GetInvoiceCommand request, CancellationToken cancellationToken)
    {
        var result = new Invoice
        {
            Id = new ModelId(1),
            Sum = new Sum(1300),
            Period = new Period(),
            IsPaid = false
        };

        return await Task.FromResult<Invoice>(result);
    }
}