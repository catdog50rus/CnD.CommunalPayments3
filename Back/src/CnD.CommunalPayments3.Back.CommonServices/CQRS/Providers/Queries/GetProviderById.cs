using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record GetProviderCommand(int Id) : IRequest<Provider>;

public class GetProviderByIdHandler : IRequestHandler<GetProviderCommand, Provider>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProviderByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Provider> Handle(GetProviderCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(request, cancellationToken);

        //TODO проверка на null
        return _mapper.Map<Provider>(entity);
    }

    private async Task<ProviderEntity?> GetAsync(GetProviderCommand request,
        CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GetRepository<ProviderEntity>();

        var entity = await repository
            .GetFirstOrDefaultAsync
            (
                predicate: x => x.Id == request.Id
            );

        return entity;
    }
}