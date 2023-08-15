using CnD.CommunalPayments3.Domen.Models.Base;

namespace CnD.CommunalPayments3.Domen.Models;

public class Period : DomenModelBase
{
    /// <summary>
    /// Год
    /// </summary>
    public string Year { get; set; } = string.Empty;

    /// <summary>
    /// Название месяца
    /// </summary>
    public MonthName Month { get; set; }

    public override string ToString()
    {
        return $"{Month} {Year}";
    }
}