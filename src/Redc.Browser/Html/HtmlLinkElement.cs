using Redc.Browser.Dom.Sets.Interfaces;
using Redc.Browser.Html.Interfaces;

namespace Redc.Browser.Html
{
    /// <summary>
    /// Links document to other resources
    /// </summary>
    internal class HtmlLinkElement : HtmlElement, IHtmlLinkElement
    {
        /// <summary>
        /// 
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CrossOrigin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Relationship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReverseLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDomTokenList RelationshipList { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Media { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HrefLang { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDomTokenList Sizes { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferrerPolicy { get; set; }
    }
}
