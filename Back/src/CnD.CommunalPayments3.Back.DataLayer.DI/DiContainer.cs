using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CnD.CommunalPayments3.Back.DataLayer.DI;

public static class DiContainer
{
    public static void AddContext(this IServiceCollection services)
    {
        services.AddDbContext<CommunalPaymentsDbContext>();
        services.AddUnitOfWork<CommunalPaymentsDbContext>();
    }
    
    
}