using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record DeleteProviderCommand(int id) : INotification;

public class DeleteInvoiceHandler : INotificationHandler<DeleteProviderCommand>
{
    public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => cancellationToken);
    }
}