using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities.Base;

namespace CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;

public class InvoiceEntity : EntityBase
{
    public int PeriodId { get; set; }

    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public PeriodEntity? Period { get; set; }

    public int ProviderId { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public ProviderEntity? Provider { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public decimal Sum { get; set; }

    public bool IsPaid { get; set; }
}

public class InvoiceServicesEntity : EntityBase
{
    public int InvoiceId { get; set; }

    public InvoiceEntity Invoice { get; set; }

    public int ServiceId { get; set; }

    public ServiceEntity Service { get; set; }

    public int Amount { get; set; }
}

public class OrderEntity : EntityBase
{
    public string FileName { get; set; }

    public byte[] OrderScreen { get; set; }
}

public class PaymentEntity : EntityBase
{
    /// <summary>
    /// Дата платежа
    /// </summary>
    public string? DatePayment { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public decimal PaymentSum { get; set; }

    public int InvoiceId { get; set; }

    /// <summary>
    /// Счет за ЖКХ
    /// </summary>
    public InvoiceEntity? Invoice { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    public int OrderId { get; set; }

    /// <summary>
    /// Скан платежки
    /// </summary>
    public OrderEntity? Order { get; set; }
}

public class PeriodEntity : EntityBase
{
    public required string Year { get; set; }

    public required string Month { get; set; }
}

public class ProviderEntity : EntityBase
{
    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public string? NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public string? WebSite { get; set; }
}

public class ServiceCounterEntity : EntityBase
{
    public int ServiceId { get; set; }

    public ServiceEntity Service { get; set; }

    public string DateCount { get; set; }

    public int Value { get; set; }
}

public class ServiceEntity : EntityBase
{
    /// <summary>
    /// Наименование услуги ЖКХ
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Предусмотрен ли счетчик услуги
    /// </summary>
    public bool IsCounter { get; set; }
}