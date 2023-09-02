using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Doman.Models;
using CnD.CommunalPayments3.Doman.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record CreatePeriodCommand(Period Period) : IRequest<Period>;

public class CreatePeriodHandler : IRequestHandler<CreatePeriodCommand, Period>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePeriodHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Period> Handle(CreatePeriodCommand request, CancellationToken cancellationToken)
    {
        var invoice = request.Period;
        
        var entity = _mapper.Map<PeriodEntity>(invoice);

        await InsertAsync(entity, cancellationToken);
 
        invoice.Id = new ModelId(entity.Id);
        
        return invoice;
    }

    private async Task InsertAsync(PeriodEntity entity, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<PeriodEntity>();
        
        await using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            await repository.InsertAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            await transaction.CommitAsync(cancellationToken);
        }
    }
}