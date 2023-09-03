using AutoFixture.Xunit2;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using Moq;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests.InvoicesTests.DeleteTests;

public class DeleteInvoiceHandlerTests : BaseTests
{
    [Theory]
    [AutoData]
    public async Task Scenario_01_ShouldReturnResult(DeleteInvoiceCommand request)
    {
        //arrange
        var cts = new CancellationTokenSource();

        BeginTransactionAsync();

        //act
        await _testHandler.Handle(request, cts.Token);

        //assert
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        _repositoryMock.Verify(x => x.Delete(request.Id), Times.Once);
    }
}