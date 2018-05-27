using Redc.Browser.Html.Interfaces;

namespace Redc.Browser.Html
{
    internal class HtmlBaseElement : HtmlElement, IHtmlBaseElement
    {
        /// <summary>
        /// 
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Target { get; set; }
    }
}
