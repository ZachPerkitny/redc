using System;
using Redc.Browser.Dom.Sets.Interfaces;
using Redc.Browser.Dom.Events;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// DOM Node Base Class (see W3C DOM4 (4.4))
    /// </summary>
    internal abstract class Node : EventTarget, INode
    {
        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        public Node()
        {

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The type of node
        /// </summary>
        public NodeType NodeType { get; private set; }

        /// <summary>
        /// The name of the node
        /// </summary>
        public string NodeName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string BaseUri { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IDocument OwnerDocument { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public INode ParentNode { get; }

        /// <summary>
        /// 
        /// </summary>
        public IElement ParentElement { get; }

        /// <summary>
        /// 
        /// </summary>
        public INodeList ChildNodes { get; }

        /// <summary>
        /// 
        /// </summary>
        public INode FirstChild { get; }

        /// <summary>
        /// 
        /// </summary>
        public INode LastChild { get; }

        /// <summary>
        /// 
        /// </summary>
        public INode PreviousSibling { get; }

        /// <summary>
        /// 
        /// </summary>
        public INode NextSibling { get; } 

        /// <summary>
        /// 
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TextContent { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasChildNodes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Normalize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deep"></param>
        /// <returns></returns>
        public INode CloneNode(bool deep = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsEqualNode(INode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public DocumentPosition CompareDocumentPosition(INode other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Contains(INode other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        public string LookupPrefix(string @namespace)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string LookupNamespaceUri(string prefix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDefaultNamespace()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public INode InsertBefore(INode node, INode child = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public INode AppendChild(INode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public INode ReplaceChild(INode node, INode child)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public INode RemoveChild(INode child)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
