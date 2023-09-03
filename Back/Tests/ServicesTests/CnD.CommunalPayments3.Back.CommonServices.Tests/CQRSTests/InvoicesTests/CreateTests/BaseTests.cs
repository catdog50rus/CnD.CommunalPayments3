using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests.InvoicesTests.CreateTests;

public class BaseTests : BaseCQRSTests<InvoiceEntity>
{
    protected readonly IRequestHandler<CreateInvoiceCommand, Invoice> _testHandler;

    public BaseTests()
    {
        _testHandler = new CreateInvoiceHandler(_unitOfWorkMock.Object, _mapper);
    }


}