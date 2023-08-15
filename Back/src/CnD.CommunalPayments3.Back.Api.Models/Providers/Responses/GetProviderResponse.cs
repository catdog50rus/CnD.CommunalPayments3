namespace CnD.CommunalPayments3.Back.Api.Models.Providers.Responses;

public class GetProviderResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public string NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public string WebSite { get; set; }
}