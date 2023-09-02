using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record DeletePeriodCommand(int Id) : INotification;

public class DeletePeriodHandler : INotificationHandler<DeletePeriodCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePeriodHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(DeletePeriodCommand request, CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<PeriodEntity>();
        repository.Delete(request.Id);

        await _unitOfWork.SaveChangesAsync();
    }
}