using CnD.CommunalPayments3.Domen.Models.Base;
using CnD.CommunalPayments3.Domen.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Domen.Models;

public class Invoice : DomenModelBase
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