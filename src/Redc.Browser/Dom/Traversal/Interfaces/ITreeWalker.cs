using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Traversal.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("TreeWalker")]
    public interface ITreeWalker
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("root")]
        INode Root { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("whatToShow")]
        FilterSettings FilterSettings { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("filter")]
        NodeFilter Filter { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("currentNode")]
        INode CurrentNode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("parentNode")]
        INode ParentNode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("firstChild")]
        INode FirstChild();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("lastChild")]
        INode LastChild();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("previousSibling")]
        INode PreviousSibling();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("nextSibling")]
        INode NextSibling();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("previousNode")]
        INode PreviousNode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("nextNode")]
        INode NextNode();
    }
}
