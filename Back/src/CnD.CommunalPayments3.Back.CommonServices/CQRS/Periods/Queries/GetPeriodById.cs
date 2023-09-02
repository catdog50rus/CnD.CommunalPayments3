using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record GetPeriodCommand(int Id) : IRequest<Period>;

public class GetPeriodByIdHandler : IRequestHandler<GetPeriodCommand, Period>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPeriodByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Period> Handle(GetPeriodCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(request, cancellationToken);

        //TODO проверка на null
        return _mapper.Map<Period>(entity);
    }

    private async Task<PeriodEntity?> GetAsync(GetPeriodCommand request,
        CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<PeriodEntity>();

        var entity = await repository
            .GetFirstOrDefaultAsync
            (
                predicate: x => x.Id == request.Id
            );

        return entity;
    }
}
