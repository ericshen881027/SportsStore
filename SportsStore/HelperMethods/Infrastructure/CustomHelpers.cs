using System.Web.Mvc;

namespace HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper htmlHelper, string[] list)
        {
            var tagBuilder = new TagBuilder("ul");
            foreach (var item in list)
            {
                var itemTag = new TagBuilder("li");
                itemTag.SetInnerText(item);
                tagBuilder.InnerHtml += itemTag;
            }

            return new MvcHtmlString(tagBuilder.ToString());
        }

        public static MvcHtmlString DisplayMessage(this HtmlHelper htmlHelper, string message)
        {
            return new MvcHtmlString($"This is the message: <p>{message}</p>");
        }
    }
}