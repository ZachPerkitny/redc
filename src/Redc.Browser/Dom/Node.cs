using Redc.Browser.Attributes;
using Redc.Browser.Dom.Collections;
using Redc.Browser.Dom.Events;
using System;
using System.Text;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// DOM Node Base Class (see W3C DOM4 (4.4))
    /// </summary>
    public abstract class Node : EventTarget
    {
        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public Node(Document owner)
        {
            OwnerDocument = owner;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The type of node
        /// </summary>
        [ES("nodeType")]
        public abstract NodeType NodeType { get; }

        /// <summary>
        /// The name of the node
        /// </summary>
        [ES("nodeName")]
        public abstract string NodeName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("baseUri")]
        public string BaseUri { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("ownerDocument")]
        public Document OwnerDocument { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("parentNode")]
        public Node ParentNode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("parentElement")]
        public Element ParentElement
        {
            get { return ParentNode as Element; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("childNodes")]
        public NodeList ChildNodes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("firstChild")]
        public Node FirstChild
        {
            get
            {
                return (ChildNodes.Length > 0) ? ChildNodes[0] : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("lastChild")]
        public Node LastChild
        {
            get
            {
                return (ChildNodes.Length > 0) ? ChildNodes[ChildNodes.Length - 1] : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("previousSibling")]
        public Node PreviousSibling
        {
            get
            {
                if (ParentNode != null)
                {
                    int i = 1;
                    int n = ParentNode.ChildNodes.Length;
                    while (i < n)
                    {
                        if (ReferenceEquals(this, ParentNode.ChildNodes[i]))
                        {
                            return ParentNode.ChildNodes[i - 1];
                        }

                        i++;
                    }
                }
                
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("nextSibling")]
        public Node NextSibling
        {
            get
            {
                if (ParentNode != null)
                {
                    int i = 0;
                    int n = ParentNode.ChildNodes.Length - 1;
                    while (i < n)
                    {
                        if (ReferenceEquals(this, ParentNode.ChildNodes[i]))
                        {
                            return ParentNode.ChildNodes[i + 1];
                        }

                        i++;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("NodeValue")]
        public virtual string NodeValue
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("textContent")]
        public virtual string TextContent
        {
            get { return null; }
            set { }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("hasChildNodes")]
        public bool HasChildNodes()
        {
            return ChildNodes.Length > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("normalize")]
        public void Normalize()
        {
            foreach (Node childNode in ChildNodes)
            {
                if (childNode is Text node)
                {
                    if (node.Length == 0)
                    {
                        RemoveChild(node);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        // TODO: Ranges
                    }
                }
                else if (childNode.HasChildNodes())
                {
                    childNode.Normalize();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deep"></param>
        /// <returns></returns>
        [ES("isEqualNode")]
        public virtual Node CloneNode(bool deep = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("isEqualNode")]
        public virtual bool IsEqualNode(Node node)
        {
            // Reference: https://www.w3.org/TR/2015/REC-dom-20151119/#concept-node-equals
            if (NodeType == node.NodeType && ChildNodes.Length == node.ChildNodes.Length)
            {
                int n = ChildNodes.Length;

                for (int i = 0; i < n; i++)
                {
                    if (!ChildNodes[i].Equals(node.ChildNodes[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [ES("compareDocumentPosition")]
        public DocumentPosition CompareDocumentPosition(Node other)
        {
            if (ReferenceEquals(this, other))
            {
                return DocumentPosition.None;
            }
            else if (!ReferenceEquals(OwnerDocument, other.OwnerDocument))
            {
                // TODO
                return DocumentPosition.None;
            }
            else if (IsAncestorOf(other))
            {
                return DocumentPosition.Contains | DocumentPosition.Preceding;
            }
            else if (IsDescendantOf(other))
            {
                return DocumentPosition.ContainedBy | DocumentPosition.Following;
            }
            else if (IsPreceding(other))
            {
                return DocumentPosition.Preceding;
            }
            else
            {
                return DocumentPosition.Following;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [ES("contains")]
        public bool Contains(Node other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        [ES("lookupPrefix")]
        public string LookupPrefix(string @namespace)
        {
            if (string.IsNullOrEmpty(@namespace))
            {
                return null;
            }

            return LocatePrefixForNamespace(@namespace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [ES("lookupNamespaceURI")]
        public string LookupNamespaceUri(string prefix)
        {
            if (prefix == string.Empty)
            {
                prefix = null;
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        [ES("isDefaultNamespace")]
        public bool IsDefaultNamespace(string @namespace)
        {
            if (@namespace == string.Empty)
            {
                @namespace = null;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        [ES("insertBefore")]
        public Node InsertBefore(Node node, Node child = null)
        {
            return PreInsert(node, child);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("appendChild")]
        public Node AppendChild(Node node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        [ES("replaceChild")]
        public Node ReplaceChild(Node node, Node child)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        [ES("removeChild")]
        public Node RemoveChild(Node child)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void EnsurePreInsertionValidity(Node node, Node child)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsAncestorOf(Node other)
        {
            return other.IsDescendantOf(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsDescendantOf(Node other)
        {
            Node node = this;

            while (node.ParentElement != null)
            {
                if (ReferenceEquals(node.ParentElement, other))
                {
                    return true;
                }

                node = node.ParentElement;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsHostIncludingInclusiveAncestorOf(Node other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsInclusiveAncestorOf(Node other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsPreceding(Node other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return IsEqualNode(obj as Node);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        protected virtual string LocatePrefixForNamespace(string @namespace)
        {
            return null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        private Node PreInsert(Node node, Node child)
        {
            // Reference: https://www.w3.org/TR/2015/REC-dom-20151119/#concept-node-pre-insert
            EnsurePreInsertionValidity(node, child);

            if (node == child)
            {
                child = node.NextSibling;
            }

            OwnerDocument.AdoptNode(node);
            Insert(node, child);
            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="child"></param>
        private void Insert(Node node, Node child)
        {
            // Reference: https://www.w3.org/TR/2015/REC-dom-20151119/#concept-node-insert
            int count = (node.NodeType == NodeType.DocumentFragment) ? node.ChildNodes.Length : 1;

            if (child != null)
            {
                // TODO: RAnges
            }
        }

        #endregion
    }
}
