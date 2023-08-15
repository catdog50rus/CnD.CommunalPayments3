namespace CnD.CommunalPayments3.Back.Api.Models.Periods.Responses;

public class GetAllPeriodsResponse
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