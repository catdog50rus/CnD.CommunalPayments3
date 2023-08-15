using System.ComponentModel.DataAnnotations;

namespace CnD.CommunalPayments3.Back.Api.Models.Invoices.Requests;

public class UpdateInvoiceRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Id Должен быть больше 0")]
    public int Id { get; init; }

    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Период должен быть выбран")]
    public int PeriodId { get; init; }

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

    public bool IsPaid { get; init; }
}