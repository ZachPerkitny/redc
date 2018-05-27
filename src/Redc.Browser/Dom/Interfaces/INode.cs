using Redc.Browser.Attributes;
using Redc.Browser.Dom.Sets.Interfaces;
using Redc.Browser.Dom.Events.Interfaces;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Node")]
    public interface INode : IEventTarget
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("nodeType")]
        NodeType NodeType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("nodeName")]
        string NodeName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("baseUri")]
        string BaseUri { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("ownerDocument")]
        IDocument OwnerDocument { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("parentNode")]
        INode ParentNode { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("parentElement")]
        IElement ParentElement { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("childNodes")]
        [SameObject]
        INodeList ChildNodes { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("firstChild")]
        INode FirstChild { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("lastChild")]
        INode LastChild { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("previousSibling")]
        INode PreviousSibling { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("nextSibling")]
        INode NextSibling { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("NodeValue")]
        string NodeValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("textContent")]
        string TextContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("hasChildNodes")]
        bool HasChildNodes();

        /// <summary>
        /// 
        /// </summary>
        [ES("normalize")]
        void Normalize();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deep"></param>
        /// <returns></returns>
        [ES("cloneNode")]
        INode CloneNode(bool deep = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("isEqualNode")]
        bool IsEqualNode(INode node);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [ES("compareDocumentPosition")]
        DocumentPosition CompareDocumentPosition(INode other);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [ES("contains")]
        bool Contains(INode other);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        [ES("lookupPrefix")]
        string LookupPrefix(string @namespace);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [ES("lookupNamespaceURI")]
        string LookupNamespaceUri(string prefix);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("isDefaultNamespace")]
        bool IsDefaultNamespace();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        [ES("insertBefore")]
        INode InsertBefore(INode node, INode child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("appendChild")]
        INode AppendChild(INode node);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        [ES("replaceChild")]
        INode ReplaceChild(INode node, INode child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        [ES("removeChild")]
        INode RemoveChild(INode child);
    }
}
