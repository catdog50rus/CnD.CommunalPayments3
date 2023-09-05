using AutoFixture;
using AutoMapper;
using Calabonga.UnitOfWork;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;

namespace CnD.CommunalPayments3.Back.CommonServices.Tests.CQRSTests;

public class BaseCQRSTests<TEntity> where TEntity : EntityBase
{
    protected readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    protected IMapper _mapper;
    
    private CancellationTokenSource _cts = new();
    protected CancellationToken Token => _cts.Token;

    protected Mock<IRepository<TEntity>> _repositoryMock = new();
    protected Mock<IDbContextTransaction> _transactionMock = new();

    protected readonly Fixture _fixture = new();

    public BaseCQRSTests()
    {
        _mapper = SetMapper();

        GetRepository();
    }
    private static IMapper SetMapper()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddMaps(typeof(Api.Models.AssemblyRunner));
            mc.AddMaps(typeof(DataLayer.Infrastructure.AssemblyRunner));
        });

        return mappingConfig.CreateMapper();
    }

    protected T GetFixtureObject<T>() => _fixture.Create<T>();

    protected void GetRepository()
    {
        _unitOfWorkMock
            .Setup(x => x.GetRepository<TEntity>(false))
            .Returns(_repositoryMock.Object)
            .Verifiable();
    }

    protected void BeginTransactionAsync()
    {
        _unitOfWorkMock
            .Setup(x => x.BeginTransactionAsync(false))
            .ReturnsAsync(_transactionMock.Object)
            .Verifiable();
    }
}
