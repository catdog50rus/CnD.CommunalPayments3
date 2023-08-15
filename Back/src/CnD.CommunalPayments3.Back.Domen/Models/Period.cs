using System.ComponentModel.DataAnnotations;
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

public enum MonthName
{
    [Display(Name = "Не выбран")]
    None = 0,

    [Display(Name = "Январь")]
    January = 1,

    [Display(Name = "Февраль")]
    February = 2,

    [Display(Name = "Март")]
    March = 3,

    [Display(Name = "Апрель")]
    April = 4,

    [Display(Name = "Май")]
    May = 5,

    [Display(Name = "Июнь")]
    June = 6,

    [Display(Name = "Июль")]
    Jule = 7,

    [Display(Name = "Август")]
    August = 8,

    [Display(Name = "Сентябрь")]
    September = 9,

    [Display(Name = "Октябрь")]
    October = 10,

    [Display(Name = "Ноябрь")]
    November = 11,

    [Display(Name = "Декабрь")]
    December = 12
}