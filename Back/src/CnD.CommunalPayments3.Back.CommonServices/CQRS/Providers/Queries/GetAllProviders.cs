using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Query;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record GetAllProvidersCommand(IPagedListQueryParams QueryParams) : IRequest<IReadOnlyList<Provider>>;

public class GetAllProvidersHandler : IRequestHandler<GetAllProvidersCommand, IReadOnlyList<Provider>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProvidersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IReadOnlyList<Provider>> Handle(GetAllProvidersCommand request, CancellationToken cancellationToken = default)
    {
        var entities = await GetAllAsync(request, cancellationToken);
        
        return _mapper.Map<IReadOnlyList<Provider>>(entities);
    }

    private async Task<IReadOnlyList<ProviderEntity>> GetAllAsync(GetAllProvidersCommand request,
        CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<ProviderEntity>();

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