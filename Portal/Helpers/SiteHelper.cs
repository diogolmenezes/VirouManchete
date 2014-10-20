using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace VirouManchete.Portal.Helpers
{
    public static class SiteHelper
    {
        //static Regex LineEnding = new Regex(@"(\r\n|\r|\n)+");

        public static MvcHtmlString Nl2br(this HtmlHelper html, string text)
        {
            var encodedText = HttpUtility.HtmlEncode(text);
            var retorno = new Regex(@"(\r)+").Replace(encodedText, "<br/>");
            return MvcHtmlString.Create(retorno);
        }
    }
}