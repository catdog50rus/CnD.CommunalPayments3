namespace CnD.CommunalPayments3.Doman.Models.Base.BaseModels.Base;

public abstract class BaseName : IProperty<string>
{
    protected string _name;

    public virtual string Value => _name;

    public BaseName(string name)
    {
        Validate(name);
        _name = name;
    }

    public virtual string GetValue()
    {
        return _name;
    }

    protected virtual void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Name", "Название сервиса не может быть пустым");
    }
}