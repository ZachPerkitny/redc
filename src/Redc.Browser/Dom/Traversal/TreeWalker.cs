using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Traversal
{
    /// <summary>
    /// 
    /// </summary>
    [ES("TreeWalker")]
    public class TreeWalker
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("root")]
        public Node Root { get; }

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
        [ES("currentNode")]
        public Node CurrentNode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("parentNode")]
        public Node ParentNode()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("firstChild")]
        public Node FirstChild()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("lastChild")]
        public Node LastChild()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("previousSibling")]
        public Node PreviousSibling()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("nextSibling")]
        public Node NextSibling()
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
        /// <returns></returns>
        [ES("nextNode")]
        public Node NextNode()
        {
            throw new System.NotImplementedException();
        }
    }
}
