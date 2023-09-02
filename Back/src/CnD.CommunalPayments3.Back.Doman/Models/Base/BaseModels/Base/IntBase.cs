namespace CnD.CommunalPayments3.Doman.Models.Base.BaseModels.Base;

public abstract class IntBase : IProperty<int>
{
    private readonly int _value = 0;

    public virtual int Value => _value;

    protected IntBase(int value)
    {
        ValidateId(value);
        _value = value;
    }

    public virtual int GetValue()
    {
        return _value;
    }

    protected virtual void ValidateId(int value)
    {
        if (value < 0)
            throw new ArgumentException("Значение не может быть меньше 0", nameof(value));
    }

    public override bool Equals(object? obj)
    {
        if (obj is IntBase value)
        {
            return _value == value.Value;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _value.ToString().GetHashCode();
    }

    public override string ToString()
    {
        return $"{_value}";
    }
}