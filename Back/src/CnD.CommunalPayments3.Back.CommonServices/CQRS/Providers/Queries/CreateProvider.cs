using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Doman.Models;
using CnD.CommunalPayments3.Doman.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record CreateProviderCommand(Provider Provider) : IRequest<Provider>;

public class CreateProviderHandler : IRequestHandler<CreateProviderCommand, Provider>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProviderHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Provider> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var invoice = request.Provider;
        
        var entity = _mapper.Map<ProviderEntity>(invoice);

        await InsertAsync(entity, cancellationToken);
 
        invoice.Id = new ModelId(entity.Id);
        
        return invoice;
    }

    private async Task InsertAsync(ProviderEntity entity, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<ProviderEntity>();
        
        await using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            await repository.InsertAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            await transaction.CommitAsync(cancellationToken);
        }
    }
}