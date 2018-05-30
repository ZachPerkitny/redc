using Redc.Browser.Attributes;
using Redc.Browser.Dom.Collections;
using Redc.Browser.Dom.Events;
using Redc.Browser.Dom.Ranges;
using Redc.Browser.Dom.Traversal;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Representation of a web page (see W3C DOM4 (4.4))
    /// </summary>
    [ES("Document")]
    public class Document : Node
    {
        /// <summary>
        /// 
        /// </summary>
        public Document()
            : base(null) { }

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("implementation")]
        public DomImplementation Implementation { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("URL")]
        public string Url { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("DocumentURI")]
        public string DocumentUri { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("origin")]
        public string Origin { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("compatMode")]
        public string CompatabilityMode { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("characterSet")]
        public string CharacterSet { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("contentType")]
        public string ContentType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("documentType")]
        public DocumentType DocumentType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("documentElement")]
        public Element DocumentElement { get; }

        /// <summary>
        /// 
        /// </summary>
        public override NodeType NodeType
        {
            get { return NodeType.Document; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NodeName
        {
            get { return "#document"; }
        }

        #endregion

        #region Public Methods

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("createElement")]
        public Element CreateElement(string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="qualifiedName"></param>
        /// <returns></returns>
        [ES("createElementNS")]
        public Element CreateElementNS(string @namespace, string qualifiedName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("createDocumentFragment")]
        public DocumentFragment CreateDocumentFragment()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ES("createTextNode")]
        public Text CreateTextNode(string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ES("createComment")]
        public Comment CreateComment(string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [ES("createProcessingInstruction")]
        public ProcessingInstruction CreateProcessingInstruction(string target, string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="deep"></param>
        /// <returns></returns>
        [ES("importNode")]
        public Node ImportNode(Node node, bool deep = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("adoptNode")]
        public Node AdoptNode(Node node)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interface"></param>
        /// <returns></returns>
        [ES("createEvent")]
        public Event CreateEvent(string @interface)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("createRange")]
        public Range CreateRange()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="whatToShow"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [ES("createNodeIterator")]
        public NodeIterator CreateNodeIterator(Node root, FilterSettings whatToShow, NodeFilter filter = null)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="whatToShow"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [ES("createTreeWalker")]
        public TreeWalker CreateTreeWalker(Node node, FilterSettings whatToShow = FilterSettings.ShowAll, NodeFilter filter = null)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
