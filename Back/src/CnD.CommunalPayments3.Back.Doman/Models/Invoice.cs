using CnD.CommunalPayments3.Doman.Models.Base;
using CnD.CommunalPayments3.Doman.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Doman.Models;

public class Invoice : DomanModelBase
{
    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public required Period Period { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public Provider Provider { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public Sum Sum { get; set; } = null!;

    /// <summary>
    /// Флаг, оплачен ли счет
    /// </summary>
    public bool IsPaid { get; set; }
}