using Redc.Browser.Attributes;

namespace Redc.Browser.Html
{
    [ES("HTMLBaseElement")]
    internal class HtmlBaseElement : HtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("href")]
        public string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("target")]
        public string Target { get; set; }
    }
}
