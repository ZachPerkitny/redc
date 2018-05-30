using Redc.Browser.Attributes;

namespace Redc.Browser.Html
{
    /// <summary>
    /// Represents the document's title or name
    /// </summary>
    [ES("HTMLTitleElement")]
    public class HtmlTitleElement : HtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("text")]
        public string Text { get; set; }
    }
}
