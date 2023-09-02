using System.Globalization;

namespace CnD.CommunalPayments3.Doman.Models.Base.BaseModels.Base;

public class DecimalBase : IProperty<decimal>
{
    private readonly decimal _value = 0;

    public virtual decimal Value => _value;

    public DecimalBase(decimal value)
    {
        Validate(value);
        _value = value;
    }

    public virtual decimal GetValue()
    {
        return _value;
    }

    protected virtual void Validate(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Значение не может быть меньше 0", nameof(value));
    }

    public override string ToString()
    {
        return $"{_value}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is DecimalBase sum)
            return _value == sum.Value;
        return false;
    }

    public override int GetHashCode()
    {
        return _value.ToString(CultureInfo.InvariantCulture).GetHashCode();
    }
}