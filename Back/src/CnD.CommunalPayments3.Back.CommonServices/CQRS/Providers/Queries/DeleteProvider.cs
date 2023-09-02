using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record DeleteProviderCommand(int Id) : INotification;

public class DeleteProviderHandler : INotificationHandler<DeleteProviderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProviderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<ProviderEntity>();
        repository.Delete(request.Id);

        await _unitOfWork.SaveChangesAsync();
    }
}