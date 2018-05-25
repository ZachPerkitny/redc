using Redc.Browser.Dom.Collections;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Representation of a web page (see W3C DOM4 (4.4))
    /// </summary>
    internal class Document : Node
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string URL { get; }

        /// <summary>
        /// 
        /// </summary>
        public string DocumentURI { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Origin { get; }

        /// <summary>
        /// 
        /// </summary>
        public string CompatMode { get; }

        /// <summary>
        /// 
        /// </summary>
        public string CharacterSet { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// 
        /// </summary>
        public DocumentType DocType { get; }

        /// <summary>
        /// 
        /// </summary>
        public Element DocumentElement { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        public HTMLCollection GetElementsByTagName(string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        public HTMLCollection GetElementsByTagNameNS(string @namespace, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classNames"></param>
        /// <returns></returns>
        public HTMLCollection GetElementsByClassName(string classNames)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
