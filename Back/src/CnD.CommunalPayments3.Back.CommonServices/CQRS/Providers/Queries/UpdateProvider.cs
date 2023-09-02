using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record UpdateProviderCommand(Provider Provider) : IRequest<Provider>;

public class UpdateProviderHandler : IRequestHandler<UpdateProviderCommand, Provider>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProviderHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Provider> Handle(UpdateProviderCommand request, CancellationToken cancellationToken = default)
    {
        var resultEntity = await UpdateAsync(request, cancellationToken);

        return _mapper.Map<Provider>(resultEntity);
    }

    private async Task<ProviderEntity?> UpdateAsync(UpdateProviderCommand request,
        CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<ProviderEntity>(request.Provider);

        var repository = _unitOfWork.GetRepository<ProviderEntity>();

        repository.Update(entity);

        await _unitOfWork.SaveChangesAsync();

        return await repository.GetFirstOrDefaultAsync(predicate: x => x.Id == request.Provider.Id.Value);
    }
}