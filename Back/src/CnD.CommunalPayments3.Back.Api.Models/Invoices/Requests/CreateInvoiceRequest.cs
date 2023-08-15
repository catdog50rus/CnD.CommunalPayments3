using System.ComponentModel.DataAnnotations;

namespace CnD.CommunalPayments3.Back.Api.Models.Invoices.Requests;

public class CreateInvoiceRequest
{
    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Период должен быть выбран")]
    public int PeriodId { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Провайдер должен быть выбран")]
    public int ProviderId { get; init; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    [Required]
    [Range(0, 10_000_000, ErrorMessage = "Сумма не может быть меньше 0")]
    public decimal Sum { get; init; }
}