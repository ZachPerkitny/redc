using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Ranges
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Range")]
    public class Range
    {       
        /// <summary>
        /// 
        /// </summary>
        [ES("startContainer")]
        public Node StartContainer { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("startOffset")]
        public int StartOffset { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("endContainer")]
        public Node EndContainer { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("endOffset")]
        public int EndOffset { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("collapsed")]
        public bool Collapsed { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("commonAncestorContainer")]
        public Node CommonAncestorContainer { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        [ES("setStart")]
        public void SetStart(Node node, int offset)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        [ES("setEnd")]
        public void SetEnd(Node node, int offset)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setStartBefore")]
        public void SetStartBefore(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setStartAfter")]
        public void SetStartAfter(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setEndBefore")]
        public void SetEndBefore(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setEndAfter")]
        public void SetEndAfter(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toStart"></param>
        [ES("collapse")]
        public void Collapse(bool toStart = false)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("selectNode")]
        public void SelectNode(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("selectNodeContents")]
        public void SelectNodeContents(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="how"></param>
        /// <param name="sourceRange"></param>
        /// <returns></returns>
        [ES("compareBoundaryPoints")]
        public short CompareBoundaryPoints(RangeType how, Range sourceRange)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("deleteContents")]
        public void DeleteContents()
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("extractContents")]
        public DocumentFragment ExtractContents()
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("cloneContents")]
        public DocumentFragment CloneContents()
        {
            throw new System.NotImplementedException();
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("insertNode")]
        public void InsertNode(Node node)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newParent"></param>
        [ES("surroundContents")]
        public void SurroundContents(Node newParent)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("cloneRange")]
        public Range CloneRange()
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [ES("isPointInRange")]
        public bool IsPointInRange(Node node, int offset)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [ES("comparePoint")]
        public short ComparePoint(Node node, int offset)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("intersectsNode")]
        public bool IntersectsNode(Node node)
        {
            throw new System.NotImplementedException();
        }
    }
}
