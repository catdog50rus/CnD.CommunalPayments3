using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record UpdateInvoiceCommand(Invoice Invoice) : IRequest<Invoice>;

public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, Invoice>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateInvoiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Invoice> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken = default)
    {
        var resultEntity = await UpdateAsync(request, cancellationToken);

        return _mapper.Map<Invoice>(resultEntity);
    }
    
    private async Task<InvoiceEntity?> UpdateAsync(UpdateInvoiceCommand request,
        CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<InvoiceEntity>(request.Invoice);
        
        var repository = _unitOfWork.GetRepository<InvoiceEntity>();

        repository.Update(entity);

        await _unitOfWork.SaveChangesAsync();

        return await repository.GetFirstOrDefaultAsync(predicate: x => x.Id == request.Invoice.Id.Value);
    }
}