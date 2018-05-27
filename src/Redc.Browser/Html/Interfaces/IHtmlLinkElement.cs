using Redc.Browser.Attributes;
using Redc.Browser.Dom.Sets.Interfaces;

namespace Redc.Browser.Html.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLLinkElement")]
    public interface IHtmlLinkElement : IHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("href")]
        string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("crossOrigin")]
        string CrossOrigin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("rel")]
        string Relationship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("rev")]
        string ReverseLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("relList")]
        IDomTokenList RelationshipList { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("media")]
        string Media { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("nonce")]
        string Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("type")]
        string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("sizes")]
        IDomTokenList Sizes { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("referrerPolicy")]
        string ReferrerPolicy { get; set; }
    }
}
