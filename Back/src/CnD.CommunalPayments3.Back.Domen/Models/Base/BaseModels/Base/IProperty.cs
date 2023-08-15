namespace CnD.CommunalPayments3.Domen.Models.Base.BaseModels.Base;

public interface IProperty<TValue>
{
    TValue Value { get; }

    TValue GetValue();
}