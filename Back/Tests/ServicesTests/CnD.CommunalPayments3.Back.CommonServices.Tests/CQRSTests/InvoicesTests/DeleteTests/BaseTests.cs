using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests.InvoicesTests.DeleteTests;

public class BaseTests : BaseCQRSTests<InvoiceEntity>
{
    protected readonly INotificationHandler<DeleteInvoiceCommand> _testHandler;

    protected BaseTests()
    {
        _testHandler = new DeleteInvoiceHandler(_unitOfWorkMock.Object);
    }
}