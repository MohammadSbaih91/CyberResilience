﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.UIHelper.PagedList
{
    public static class PagedListExtensions
    {
        public static PagedListModel<T> ToPagedListModel<T>(
            this IEnumerable<T> list,
            int totalItems,
            int currentPage,
            int pageSize,
            string urlStringFormat)
        {
            var pagedListModel = new PagedListModel<T>
            {
                TotalItems = totalItems,
                CurrentPage = currentPage,
                PageSize = pageSize,
                UrlStringFormat = urlStringFormat,
                ItemsList = list.ToList()
            };
            return pagedListModel;
        }
    }
}