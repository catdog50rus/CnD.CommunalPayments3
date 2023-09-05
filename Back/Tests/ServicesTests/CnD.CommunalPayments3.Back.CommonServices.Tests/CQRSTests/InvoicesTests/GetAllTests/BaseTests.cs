using System.Linq.Expressions;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using CnD.CommunalPayments3.Back.Services.CommonServices.CQRS.Invoices.Queries;
using CnD.CommunalPayments3.Doman.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Moq;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests.InvoicesTests.GetAllTests;

public class BaseTests : BaseCQRSTests<InvoiceEntity>
{
    protected readonly IRequestHandler<GetAllInvoicesCommand, IReadOnlyList<Invoice>> _testHandler;

    protected BaseTests()
    {
        _testHandler = new GetAllInvoicesHandler(_unitOfWorkMock.Object, _mapper);
    }

    protected void GetPagedListAsync(IPagedList<InvoiceEntity> result)
    {
        _repositoryMock
            .Setup(x => x.GetPagedListAsync(
                It.IsAny<Expression<Func<InvoiceEntity, bool>>>(),
                It.IsAny<Func<IQueryable<InvoiceEntity>, IOrderedQueryable<InvoiceEntity>>>(),
                It.IsAny<Func<IQueryable<InvoiceEntity>,IIncludableQueryable<InvoiceEntity, object>>>(),
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                true,
                It.IsAny<CancellationToken>(),
                false, 
                false))
            .ReturnsAsync(result)
            .Verifiable();
    }
}