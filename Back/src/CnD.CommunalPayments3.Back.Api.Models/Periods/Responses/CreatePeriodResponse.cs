namespace CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;

public class CreatePeriodResponse
{
    public int Id { get; init; }

    /// <summary>
    /// Год
    /// </summary>
    public string Year { get; init; }

    /// <summary>
    /// Название месяца
    /// </summary>
    public string Month { get; init; }
}