using CnD.CommunalPayments3.Domen.Models;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;
using MediatR;

namespace CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Periods.Queries;

public record GetPeriodCommand(int Id) : IRequest<Period>;

public class GetInvoiceByIdHandler : IRequestHandler<GetPeriodCommand, Period>
{
    public async Task<Period> Handle(GetPeriodCommand request, CancellationToken cancellationToken)
    {
        var result = new Period()
        {
            Id = new ModelId(1),
            Month = MonthName.August,
            Year = DateTime.Today.Year.ToString()
        };

        return await Task.FromResult(result);
    }
}
