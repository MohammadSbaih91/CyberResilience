using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.UIHelper.PagedList
{
    public interface IPagedListModel
    {
        int TotalItems { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        string UrlStringFormat { get; set; }

        /// <summary>
        /// The id of an html element to replace using ajax
        /// </summary>
        string ItemId { get; set; }

        int TotalPages { get; }
    }
}