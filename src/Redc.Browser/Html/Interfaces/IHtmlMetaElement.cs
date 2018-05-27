using Redc.Browser.Attributes;

namespace Redc.Browser.Html.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLMetaElement")]
    interface IHtmlMetaElement : IHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("name")]
        string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("httpEquiv")]
        string HttpEquivalent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("content")]
        string Content { get; set; }
    }
}
