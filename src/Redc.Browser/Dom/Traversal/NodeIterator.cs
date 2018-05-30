using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Traversal
{
    /// <summary>
    /// 
    /// </summary>
    [ES("NodeIterator")]
    public class NodeIterator
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("root")]
        public Node Root { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("pointerBeforeReferenceNode")]
        public bool PointerBeforeReferenceNode { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("whatToShow")]
        public FilterSettings FilterSettings { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("filter")]
        public NodeFilter Filter { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("nextNode")]
        public Node NextNode()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("previousNode")]
        public Node PreviousNode()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("detach")]
        public void Detach()
        {
            throw new System.NotImplementedException();
        }
    }
}
