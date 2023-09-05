using AutoFixture.Xunit2;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using Shouldly;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests.InvoicesTests.CreateTests;

public class CreateInvoiceHandlerTests : BaseTests
{
    [Theory]
    [AutoData]
    public async Task Scenario_01_ShouldReturnResult(CreateInvoiceCommand request)
    {
        //arrange
        BeginTransactionAsync();

        //act
        var result = await _testHandler.Handle(request, Token);

        //assert
        result.ShouldNotBeNull();

        result.Id.ShouldBe(request.Invoice.Id);
    }
}