using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record DeleteInvoiceCommand(int id) : INotification;

public class DeleteInvoiceHandler : INotificationHandler<DeleteInvoiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInvoiceHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<InvoiceEntity>();
        repository.Delete(request.id);

        return Task.CompletedTask;
    }
}