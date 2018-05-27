using Redc.Browser.Attributes;
using Redc.Browser.Dom.Events.Interfaces;
using Redc.Browser.Dom.Ranges.Interfaces;
using Redc.Browser.Dom.Sets.Interfaces;
using Redc.Browser.Dom.Traversal;
using Redc.Browser.Dom.Traversal.Interfaces;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Document")]
    public interface IDocument : INode
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("implementation")]
        IDomImplementation Implementation { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("URL")]
        string Url { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("DocumentURI")]
        string DocumentUri { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("origin")]
        string Origin { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("compatMode")]
        string CompatabilityMode { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("characterSet")]
        string CharacterSet { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("contentType")]
        string ContentType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("documentType")]
        IDocumentType DocumentType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("documentElement")]
        IElement DocumentElement { get; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("createElement")]
        IElement CreateElement(string localName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="qualifiedName"></param>
        /// <returns></returns>
        [ES("createElement")]
        IElement CreateElementNS(string @namespace, string qualifiedName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("createElement")]
        IDocumentFragment CreateDocumentFragment();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ES("createElement")]
        IText CreateTextNode(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ES("createComment")]
        IComment CreateComment(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [ES("createProcessingInstruction")]
        IProcessingInstruction CreateProcessingInstruction(string target, string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="deep"></param>
        /// <returns></returns>
        [ES("importNode")]
        INode ImportNode(INode node, bool deep = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("adoptNode")]
        INode AdoptNode(INode node);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interface"></param>
        /// <returns></returns>
        [ES("createEvent")]
        IEvent CreateEvent(string @interface);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("createRange")]
        IRange CreateRange();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="whatToShow"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [ES("createNodeIterator")]
        INodeIterator CreateNodeIterator(INode root, FilterSettings whatToShow, NodeFilter filter = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="whatToShow"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [ES("createTreeWalker")]
        ITreeWalker CreateTreeWalker(INode node, FilterSettings whatToShow = FilterSettings.ShowAll, NodeFilter filter = null);
    }
}
