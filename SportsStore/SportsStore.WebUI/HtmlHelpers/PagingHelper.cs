using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", pageUrl(i));
                tagBuilder.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tagBuilder.AddCssClass("selected");
                }

                stringBuilder.Append(tagBuilder);
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}