using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record GetProviderCommand(int Id) : IRequest<Provider>;

public class GetInvoiceByIdHandler : IRequestHandler<GetProviderCommand, Provider>
{
    public async Task<Provider> Handle(GetProviderCommand request, CancellationToken cancellationToken)
    {
        var result = new Provider()
        {
            Id = new ModelId(1),
            NameProvider = new ServiceName("Сервис"),
            WebSite = new WebSite("web")
        };

        return await Task.FromResult(result);
    }
}