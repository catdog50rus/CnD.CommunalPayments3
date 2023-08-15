using CnD.CommunalPayments3.Domen.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record DeleteInvoiceCommand(int id) : INotification;

public class DeleteInvoiceHandler : INotificationHandler<DeleteInvoiceCommand>
{
    public async Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => cancellationToken);
    }
}