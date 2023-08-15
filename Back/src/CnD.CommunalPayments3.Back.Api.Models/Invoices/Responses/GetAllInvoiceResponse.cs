namespace CnD.CommunalPayments3.Back.Api.Models.Invoices.Responses;

public class GetAllInvoiceResponse
{
    public int Id { get; init; }

    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public int PeriodId { get; init; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public int ProviderId { get; init; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public decimal Sum { get; init; }

    public bool IsPaid { get; set; }
}