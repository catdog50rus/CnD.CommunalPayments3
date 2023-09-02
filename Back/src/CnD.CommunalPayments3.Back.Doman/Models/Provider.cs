using CnD.CommunalPayments3.Doman.Models.Base;
using CnD.CommunalPayments3.Doman.Models.Base.BaseModels;

namespace CnD.CommunalPayments3.Doman.Models;

/// <summary>
/// Поставщик услуги
/// </summary>
public class Provider : DomanModelBase
{
    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public ServiceName NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public WebSite WebSite { get; set; }
}