using Redc.Browser.Attributes;
using Redc.Browser.Dom.Sets;

namespace Redc.Browser.Html
{
    /// <summary>
    /// Links document to other resources
    /// </summary>
    [ES("HTMLLinkElement")]
    public class HtmlLinkElement : HtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("href")]
        public string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("crossOrigin")]
        public string CrossOrigin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("rel")]
        public string Relationship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("rev")]
        public string ReverseLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("relList")]
        public DomTokenList RelationshipList { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("media")]
        public string Media { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("nonce")]
        public string Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("hrefLang")]
        public string HrefLang { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("sizes")]
        public DomTokenList Sizes { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("referrerPolicy")]
        public string ReferrerPolicy { get; set; }
    }
}
