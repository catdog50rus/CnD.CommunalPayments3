using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Domen.Core.Query
{
    public class QueryParamsBase : IQueryParams
    {
        public string Search { get ; set ; } = string.Empty;
    }

    public interface IQueryParams
    {
        string Search { get; set; }
    }
}
