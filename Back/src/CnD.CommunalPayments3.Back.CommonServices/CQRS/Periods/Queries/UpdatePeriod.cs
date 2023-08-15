using CnD.CommunalPayments3.Domen.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record UpdatePeriodCommand(Period Period) : IRequest<Period>;

public class UpdateInvoiceHandler : IRequestHandler<UpdatePeriodCommand, Period>
{
    public async Task<Period> Handle(UpdatePeriodCommand request, CancellationToken cancellationToken = default)
    {
        var result = new Period
        {
            Id = request.Period.Id,
            Month = request.Period.Month,
            Year = request.Period.Year
        };
        
        return await Task.FromResult(result);
    }
}