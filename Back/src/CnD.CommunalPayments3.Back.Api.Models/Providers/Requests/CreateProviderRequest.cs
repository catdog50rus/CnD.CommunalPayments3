namespace CnD.CommunalPayments3.Back.Api.Models.Providers.Requests;

public class CreateProviderRequest
{
    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public string NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public string WebSite { get; set; }
}