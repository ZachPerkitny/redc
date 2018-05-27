using Redc.Browser.Html.Interfaces;

namespace Redc.Browser.Html
{
    /// <summary>
    /// 
    /// </summary>
    internal class HtmlMetaElement : HtmlElement, IHtmlMetaElement
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HttpEquivalent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
    }
}
