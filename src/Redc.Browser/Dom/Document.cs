using Redc.Browser.Dom.Collections.Interfaces;
using Redc.Browser.Dom.Events;
using Redc.Browser.Dom.Events.Interfaces;
using Redc.Browser.Dom.Interfaces;
using Redc.Browser.Dom.Ranges.Interfaces;
using Redc.Browser.Dom.Traversal;
using Redc.Browser.Dom.Traversal.Interfaces;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Representation of a web page (see W3C DOM4 (4.4))
    /// </summary>
    internal class Document : Node, IDocument
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public IDomImplementation Implementation { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// 
        /// </summary>
        public string DocumentUri { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Origin { get; }

        /// <summary>
        /// 
        /// </summary>
        public string CompatabilityMode { get; }

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
        public IDocumentType DocumentType { get; }

        /// <summary>
        /// 
        /// </summary>
        public IElement DocumentElement { get; }

        #endregion

        #region Public Methods

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        public IElement CreateElement(string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="qualifiedName"></param>
        /// <returns></returns>
        public IElement CreateElementNS(string @namespace, string qualifiedName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDocumentFragment CreateDocumentFragment()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IText CreateTextNode(string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IComment CreateComment(string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IProcessingInstruction CreateProcessingInstruction(string target, string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="deep"></param>
        /// <returns></returns>
        public INode ImportNode(INode node, bool deep = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public INode AdoptNode(INode node)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interface"></param>
        /// <returns></returns>
        public Event CreateEvent(string @interface)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IRange CreateRange()
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
        public INodeIterator CreateNodeIterator(INode root, FilterSettings whatToShow, NodeFilter filter = null)
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
        public ITreeWalker CreateTreeWalker(INode node, FilterSettings whatToShow = FilterSettings.ShowAll, NodeFilter filter = null)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
