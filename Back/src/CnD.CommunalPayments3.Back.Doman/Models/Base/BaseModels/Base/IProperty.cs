namespace CnD.CommunalPayments3.Doman.Models.Base.BaseModels.Base;

public interface IProperty<TValue>
{
    TValue Value { get; }

    TValue GetValue();
}