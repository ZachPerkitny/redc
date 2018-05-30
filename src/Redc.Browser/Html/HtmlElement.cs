using Redc.Browser.Attributes;
using Redc.Browser.Dom;

namespace Redc.Browser.Html
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLElement")]
    public abstract class HtmlElement : Element
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("lang")]
        public string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("translated")]
        public bool IsTranslated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("dir")]
        public string Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("hidden")]
        public bool IsHidden { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("tabIndex")]
        public long TabIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("accessKey")]
        public string AccessKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("draggable")]
        public bool IsDraggable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("spellcheck")]
        public bool UseSpellCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("innerText")]
        public string InnerText { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        [ES("click")]
        public void Click()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("focus")]
        public void Focus()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("blur")]
        public void Blur()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("forceSpellCheck")]
        public void ForceSpellCheck()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
