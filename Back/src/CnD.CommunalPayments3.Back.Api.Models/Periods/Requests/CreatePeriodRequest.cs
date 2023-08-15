using System.ComponentModel.DataAnnotations;

namespace CnD.CommunalPayments3.Back.Api.Models.Periods.Requests;

public class CreatePeriodRequest
{
    /// <summary>
    /// Год
    /// </summary>
    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string Year { get; init; }

    /// <summary>
    /// Название месяца
    /// </summary>
    [Required]
    [StringLength(8, MinimumLength = 3)]
    public string Month { get; init; }
}