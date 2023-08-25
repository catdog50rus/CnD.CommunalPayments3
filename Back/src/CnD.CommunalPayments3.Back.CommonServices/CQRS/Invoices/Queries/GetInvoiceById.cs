using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record GetInvoiceCommand(int Id) : IRequest<Invoice>;

public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceCommand, Invoice>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInvoiceByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Invoice> Handle(GetInvoiceCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await GetAsync(request, cancellationToken);
        
        //TODO проверка на null
        return _mapper.Map<Invoice>(entity);
    }

    private async Task<InvoiceEntity?> GetAsync(GetInvoiceCommand request,
        CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<InvoiceEntity>();

        var entity = await repository
            .GetFirstOrDefaultAsync
            (
                predicate: x => x.Id == request.Id
            );

        return entity;
    }
}