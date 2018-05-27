using Redc.Browser.Html.Interfaces;

namespace Redc.Browser.Html
{
    /// <summary>
    /// Represents the document's title or name
    /// </summary>
    internal class HtmlTitleElement : HtmlElement, IHtmlTitleElement
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }
    }
}
