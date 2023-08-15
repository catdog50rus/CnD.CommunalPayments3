using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record DeletePeriodCommand(int id) : INotification;

public class DeleteInvoiceHandler : INotificationHandler<DeletePeriodCommand>
{
    public async Task Handle(DeletePeriodCommand request, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => cancellationToken);
    }
}