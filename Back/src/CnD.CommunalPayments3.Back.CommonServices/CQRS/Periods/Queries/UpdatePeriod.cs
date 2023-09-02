using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record UpdatePeriodCommand(Period Period) : IRequest<Period>;

public class UpdatePeriodHandler : IRequestHandler<UpdatePeriodCommand, Period>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePeriodHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Period> Handle(UpdatePeriodCommand request, CancellationToken cancellationToken = default)
    {
        var resultEntity = await UpdateAsync(request, cancellationToken);

        return _mapper.Map<Period>(resultEntity);
    }

    private async Task<PeriodEntity?> UpdateAsync(UpdatePeriodCommand request,
        CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<PeriodEntity>(request.Period);

        var repository = _unitOfWork.GetRepository<PeriodEntity>();

        repository.Update(entity);

        await _unitOfWork.SaveChangesAsync();

        return await repository.GetFirstOrDefaultAsync(predicate: x => x.Id == request.Period.Id.Value);
    }
}