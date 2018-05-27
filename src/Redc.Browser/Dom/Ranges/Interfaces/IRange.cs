using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Ranges.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Range")]
    public interface IRange
    {       
        /// <summary>
        /// 
        /// </summary>
        [ES("startContainer")]
        INode StartContainer { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("startOffset")]
        int StartOffset { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("endContainer")]
        INode EndContainer { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("endOffset")]
        int EndOffset { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("collapsed")]
        bool Collapsed { get; }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("commonAncestorContainer")]
        INode CommonAncestorContainer { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        [ES("setStart")]
        void SetStart(INode node, int offset);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        [ES("setEnd")]
        void SetEnd(INode node, int offset);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setStartBefore")]
        void SetStartBefore(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setStartAfter")]
        void SetStartAfter(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setEndBefore")]
        void SetEndBefore(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setEndAfter")]
        void SetEndAfter(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toStart"></param>
        [ES("collapse")]
        void Collapse(bool toStart = false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("selectNode")]
        void SelectNode(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("selectNodeContents")]
        void SelectNodeContents(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="how"></param>
        /// <param name="sourceRange"></param>
        /// <returns></returns>
        [ES("compareBoundaryPoints")]
        short CompareBoundaryPoints(RangeType how, IRange sourceRange);
        
        /// <summary>
        /// 
        /// </summary>
        [ES("deleteContents")]
        void DeleteContents();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("extractContents")]
        IDocumentFragment ExtractContents();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("cloneContents")]
        IDocumentFragment CloneContents();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("insertNode")]
        void InsertNode(INode node);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newParent"></param>
        [ES("surroundContents")]
        void SurroundContents(INode newParent);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("cloneRange")]
        IRange CloneRange();
        
        /// <summary>
        /// 
        /// </summary>
        [ES("detach")]
        void Detach();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [ES("isPointInRange")]
        bool IsPointInRange(INode node, int offset);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [ES("comparePoint")]
        short ComparePoint(INode node, int offset);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [ES("intersectsNode")]
        bool IntersectsNode(INode node);
    }
}
