using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Traversal.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("NodeIterator")]
    public interface INodeIterator
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("root")]
        INode Root { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("pointerBeforeReferenceNode")]
        bool PointerBeforeReferenceNode { get; }

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
        /// <returns></returns>
        [ES("nextNode")]
        INode NextNode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("previousNode")]
        INode PreviousNode();

        /// <summary>
        /// 
        /// </summary>
        [ES("detach")]
        void Detach();
    }
}
