using Redc.Browser.Dom;
using Redc.Browser.Html.Interfaces;

namespace Redc.Browser.Html
{
    internal abstract class HtmlElement : Element, IHtmlElement
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTranslated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TabIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDraggable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UseSpellCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InnerText { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void Click()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Focus()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Blur()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ForceSpellCheck()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
