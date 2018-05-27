using Redc.Browser.Dom.Collections.Interfaces;
using Redc.Browser.Dom.Interfaces;
using Redc.Browser.Dom.Sets.Interfaces;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    internal class Element : Node, IElement
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string NamespaceUri { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// 
        /// </summary>
        public string LocalName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string TagName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// 
        /// </summary>
        public IDomTokenList ClassList { get; }

        /// <summary>
        /// 
        /// </summary>
        public INamedNodeMap Attributes { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetAttribute(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        public string GetAttributeNS(string @namespace, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void SetAttribute(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeNS(string @namespace, string name, string value)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void RemoveAttribute(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        public void RemoveAttributeNS(string @namespace, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        public IHtmlCollection GetElementsByTagName(string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        public IHtmlCollection GetElementsByTagNameNS(string @namespace, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classNames"></param>
        /// <returns></returns>
        public IHtmlCollection GetElementsByClassName(string classNames)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
