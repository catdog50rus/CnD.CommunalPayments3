using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Domen.Core.Query
{
    public class PagedListQueryParams : QueryParamsBase, IPagedListQueryParams
    {
        public int PageIndex {get; set;}

        public int PageSize { get; set;}

        public QueryParamsSortDirection SortDirection { get; set; }
    }

    public interface IPagedListQueryParams : IQueryParams
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }
    }

    public enum QueryParamsSortDirection
    {
        Ascending,
        Descending
    }
}