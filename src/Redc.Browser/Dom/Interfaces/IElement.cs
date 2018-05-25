using Redc.Browser.Attributes;
using Redc.Browser.Dom.Collections.Interfaces;

namespace Redc.Browser.Dom.Interfaces
{
    [ES("Element")]
    internal interface IElement : INode
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

        string GetAttribute(string name);

        string GetAttributeNS(string @namespace, string localName);

        void SetAttribute(string name);

        void SetAttribute(string @namespace, string name, string value);

        void RemoveAttribute(string name);

        void RemoveAttributeNS(string @namespace, string localName);
    }
}
