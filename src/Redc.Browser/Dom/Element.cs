using Redc.Browser.Attributes;
using Redc.Browser.Dom.Collections;
using Redc.Browser.Dom.Sets;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Element")]
    public class Element : Node
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        public Element(Document owner, string localName, string @namespace = null, string namespacePrefix = null)
            : base(owner)
        {
            LocalName = localName;
            NamespaceUri = @namespace;
            Prefix = namespacePrefix;
            Attributes = new NamedNodeMap();
        }

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("namespaceURI")]
        public string NamespaceUri { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("prefix")]
        public string Prefix { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("localName")]
        public string LocalName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("tagName")]
        public string TagName
        {
            get
            {
                string qualifiedName;

                if (!string.IsNullOrEmpty(Prefix))
                {
                    qualifiedName = $"{Prefix}:{LocalName}";
                }
                else
                {
                    qualifiedName = LocalName;
                }

                if (NamespaceUri == NamespaceUris.HtmlNamespace)
                {
                    qualifiedName = qualifiedName.ToUpper();
                }

                return qualifiedName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("id")]
        public string ID { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("className")]
        public string ClassName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("classList")]
        public DomTokenList ClassList { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("attributes")]
        public NamedNodeMap Attributes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public override NodeType NodeType
        {
            get { return NodeType.Element; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NodeName
        {
            get { return TagName; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("getAttribute")]
        public string GetAttribute(string name)
        {
            if (NamespaceUri == NamespaceUris.HtmlNamespace)
            {
                name = name.ToLower();
            }

            return Attributes.GetNamedItem(name)?.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getAttributeNS")]
        public string GetAttributeNS(string @namespace, string localName)
        {
            if (@namespace == string.Empty)
            {
                @namespace = null;
            }

            return Attributes.GetNamedItemNS(@namespace, localName)?.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [ES("setAttribute")]
        public void SetAttribute(string name, string value)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [ES("setAttributeNS")]
        public void SetAttributeNS(string @namespace, string name, string value)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [ES("removeAttribute")]
        public void RemoveAttribute(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        [ES("removeAttributeNS")]
        public void RemoveAttributeNS(string @namespace, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getElementsByTagName")]
        public HtmlCollection GetElementsByTagName(string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getElementsByTagNameNS")]
        public HtmlCollection GetElementsByTagNameNS(string @namespace, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classNames"></param>
        /// <returns></returns>
        [ES("getElementsByClassName")]
        public HtmlCollection GetElementsByClassName(string classNames)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
