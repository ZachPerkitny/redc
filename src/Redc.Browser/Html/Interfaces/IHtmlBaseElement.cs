using Redc.Browser.Attributes;

namespace Redc.Browser.Html.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLBaseElement")]
    public interface IHtmlBaseElement : IHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        string Href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Target { get; set; }
    }
}
