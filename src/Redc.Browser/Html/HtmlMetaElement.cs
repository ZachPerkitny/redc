using Redc.Browser.Attributes;

namespace Redc.Browser.Html
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLMetaElement")]
    public class HtmlMetaElement : HtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("httpEquiv")]
        public string HttpEquivalent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("content")]
        public string Content { get; set; }
    }
}
