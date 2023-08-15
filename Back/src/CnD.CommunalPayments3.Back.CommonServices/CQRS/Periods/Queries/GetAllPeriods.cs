using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Query;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record GetAllPeriodsCommand(IPagedListQueryParams QueryParams) : IRequest<IReadOnlyList<Period>>;

public class GetAllPeriodsHandler : IRequestHandler<GetAllPeriodsCommand, IReadOnlyList<Period>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllPeriodsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IReadOnlyList<Period>> Handle(GetAllPeriodsCommand request, CancellationToken cancellationToken = default)
    {
        var entities = await GetAllAsync(request, cancellationToken);
        
        return _mapper.Map<IReadOnlyList<Period>>(entities);
    }

    private async Task<IReadOnlyList<PeriodEntity>> GetAllAsync(GetAllPeriodsCommand request,
        CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<PeriodEntity>();

        var entities = await repository
            .GetPagedListAsync
            (
                orderBy: x => x.OrderBy(entity => entity.Id),
                pageIndex: request.QueryParams.PageIndex,
                pageSize: request.QueryParams.PageSize,
                cancellationToken: cancellationToken
            );

        return entities.Items.AsReadOnly();
    }
}