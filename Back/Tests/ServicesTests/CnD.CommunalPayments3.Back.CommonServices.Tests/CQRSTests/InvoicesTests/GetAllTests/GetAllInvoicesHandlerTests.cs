using AutoFixture.Xunit2;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using CnD.CommunalPayments3.Doman.Query;
using Shouldly;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests.InvoicesTests.GetAllTests;

public class GetAllInvoicesHandlerTests : BaseTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnResult()
    {
        //arrange
        var queryParam = new PagedListQueryParams()
        {
            PageIndex = 0,
            PageSize = 10,
        };
        var request = new GetAllInvoicesCommand(queryParam, Token);

        var invoices = new List<InvoiceEntity> { GetFixtureObject<InvoiceEntity>() };
        invoices.ForEach(x=>x.Period.Month = "Февраль");

        GetPagedListAsync(invoices.ToPagedList(0, 20));

        //act
        var result = await _testHandler.Handle(request, Token);

        //assert
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        
        result[0].Id.Value.ShouldBe(invoices[0].Id);
    }
}