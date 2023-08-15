using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;

public record CreateInvoiceCommand(Invoice Invoice) : IRequest<Invoice>;

public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateInvoiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = request.Invoice;
        
        var entity = _mapper.Map<InvoiceEntity>(invoice);

        await InsertAsync(entity, cancellationToken);
 
        invoice.Id = new ModelId(entity.Id);
        
        return invoice;
    }

    private async Task InsertAsync(InvoiceEntity entity, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<InvoiceEntity>();
        
        await using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            await repository.InsertAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            await transaction.CommitAsync(cancellationToken);
        }
    }
}