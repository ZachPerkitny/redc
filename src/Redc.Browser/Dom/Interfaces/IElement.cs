using Redc.Browser.Attributes;
using Redc.Browser.Dom.Collections.Interfaces;
using Redc.Browser.Dom.Sets.Interfaces;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Element")]
    public interface IElement : INode
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("namespaceURI")]
        string NamespaceUri { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("prefix")]
        string Prefix { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("localName")]
        string LocalName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("tagName")]
        string TagName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("id")]
        string ID { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("className")]
        string ClassName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("classList")]
        IDomTokenList ClassList { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("attributes")]
        INamedNodeMap Attributes { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("getAttribute")]
        string GetAttribute(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getAttributeNS")]
        string GetAttributeNS(string @namespace, string localName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [ES("setAttribute")]
        void SetAttribute(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [ES("setAttributeNS")]
        void SetAttributeNS(string @namespace, string name, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [ES("removeAttribute")]
        void RemoveAttribute(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        [ES("removeAttributeNS")]
        void RemoveAttributeNS(string @namespace, string localName);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getElementsByTagName")]
        IHtmlCollection GetElementsByTagName(string localName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getElementsByTagNameNS")]
        IHtmlCollection GetElementsByTagNameNS(string @namespace, string localName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classNames"></param>
        /// <returns></returns>
        [ES("getElementsByClassName")]
        IHtmlCollection GetElementsByClassName(string classNames);
    }
}
