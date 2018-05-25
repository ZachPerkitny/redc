using Redc.Browser.Attributes;

namespace Redc.Browser.Html.Interfaces
{
    /// <summary>
    /// Basic interface that all HTML elements inherit from.
    /// </summary>
    [ES("HTMLElement")]
    interface IHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("title")]
        string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("lang")]
        string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("translated")]
        bool IsTranslated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("dir")]
        string Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("hidden")]
        bool IsHidden { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("tabIndex")]
        long TabIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("accessKey")]
        string AccessKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("draggable")]
        bool IsDraggable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("spellcheck")]
        bool UseSpellCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("innerText")]
        [TreatNullAsEmptyString]
        string InnerText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("click")]
        void Click();

        /// <summary>
        /// 
        /// </summary>
        [ES("focus")]
        void Focus();

        /// <summary>
        /// 
        /// </summary>
        [ES("blur")]
        void Blur();

        /// <summary>
        /// 
        /// </summary>
        [ES("forceSpellCheck")]
        void ForceSpellCheck();
    }
}
