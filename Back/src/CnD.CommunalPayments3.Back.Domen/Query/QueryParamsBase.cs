namespace CnD.CommunalPayments3.Domen.Query
{
    public class QueryParamsBase : IQueryParams
    {
        public string? Search { get ; set ; } = string.Empty;
    }

    public interface IQueryParams
    {
        string? Search { get; set; }
    }
}
