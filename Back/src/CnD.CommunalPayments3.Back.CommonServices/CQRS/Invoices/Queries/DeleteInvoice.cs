using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record DeleteInvoiceCommand(int Id) : INotification;

public class DeleteInvoiceHandler : INotificationHandler<DeleteInvoiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInvoiceHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<InvoiceEntity>();
        repository.Delete(request.Id);

        await _unitOfWork.SaveChangesAsync();
    }
}