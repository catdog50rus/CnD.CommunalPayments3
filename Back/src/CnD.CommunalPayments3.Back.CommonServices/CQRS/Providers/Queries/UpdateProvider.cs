using CnD.CommunalPayments3.Domen.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Providers.Queries;

public record UpdateProviderCommand(Provider Provider) : IRequest<Provider>;

public class UpdateInvoiceHandler : IRequestHandler<UpdateProviderCommand, Provider>
{
    public async Task<Provider> Handle(UpdateProviderCommand request, CancellationToken cancellationToken = default)
    {
        var result = new Provider
        {
            Id = request.Provider.Id,
            NameProvider = request.Provider.NameProvider,
            WebSite = request.Provider.WebSite
        };
        
        return await Task.FromResult(result);
    }
}