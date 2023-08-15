using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Query;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record GetAllInvoicesCommand(IPagedListQueryParams QueryParams, CancellationToken CancellationToken) : IRequest<IReadOnlyList<Invoice>>;

public class GetAllInvoicesHandler : IRequestHandler<GetAllInvoicesCommand, IReadOnlyList<Invoice>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllInvoicesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IReadOnlyList<Invoice>> Handle(GetAllInvoicesCommand request, CancellationToken cancellationToken = default)
    {
        var entities = await GetAllAsync(request, cancellationToken);

        var result = _mapper.Map<IReadOnlyList<Invoice>>(entities);
        
        return result;
    }

    private async Task<IReadOnlyList<InvoiceEntity>> GetAllAsync(GetAllInvoicesCommand request,
        CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<InvoiceEntity>();

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