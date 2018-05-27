using Redc.Browser.Attributes;

namespace Redc.Browser.Html.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLTitleElement")]
    public interface IHtmlTitleElement : IHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        string Text { get; set; }
    }
}
