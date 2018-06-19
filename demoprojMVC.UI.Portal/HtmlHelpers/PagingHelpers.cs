using System;
using System.Text;
using System.Web.Mvc;
using demoprojMVC.UI.Portal.Helpers;
using demoprojMVC.UI.Portal.Models;

namespace demoprojMVC.UI.Portal.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,  PagingInfo pagingInfo, Func<int, string> pageUrl, string elemId = "pageTo")
        {
            StringBuilder result = new StringBuilder();
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id",elemId);
            selectTag.MergeAttribute("name", "page");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("option");
                tag.MergeAttribute("value",pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.MergeAttribute("selected","true");
                    
                }
                selectTag.InnerHtml += tag.ToString();
            }
            result.Append(selectTag.ToString());
            return MvcHtmlString.Create(result.ToString());
        }

        public static string CodeTransferToStr(this HtmlHelper html, string firstValue, string secValue)
        {
            return XmlHelper.GetOneByXPathBeUsedSimpleData(firstValue, secValue, "Text");
        }
    }
}