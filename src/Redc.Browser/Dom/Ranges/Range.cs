using System;
using System.Collections.Generic;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Ranges
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Range")]
    public class Range
    {
        private Boundary _start;
        private Boundary _end;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        public Range(Document document)
        {
            _start = new Boundary { Node = document, Offset = 0 };
            _end = new Boundary { Node = document, Offset = 0 };
        }

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("startContainer")]
        public Node StartContainer
        {
            get { return _start.Node; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("startOffset")]
        public int StartOffset
        {
            get { return _start.Offset; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("endContainer")]
        public Node EndContainer
        {
            get { return _end.Node; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("endOffset")]
        public int EndOffset
        {
            get { return _end.Offset; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("collapsed")]
        public bool Collapsed
        {
            get { return _start.Node == _end.Node; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ES("commonAncestorContainer")]
        public Node CommonAncestorContainer
        {
            get
            {
                Node container = _start.Node;
                while (container != null && container.IsInclusiveAncestorOf(_end.Node))
                {
                    container = container.ParentNode;
                }

                return container;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Node Root
        {
            get
            {
                return _start.Node.Root;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        [ES("setStart")]
        public void SetStart(Node node, int offset)
        {
            SetBoundary(node, offset, true);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        [ES("setEnd")]
        public void SetEnd(Node node, int offset)
        {
            SetBoundary(node, offset, false);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setStartBefore")]
        public void SetStartBefore(Node node)
        {
            Node parent = node.ParentNode;

            if (parent == null)
            {
                throw new Exception();
            }

            SetBoundary(parent, node.Index, true);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setStartAfter")]
        public void SetStartAfter(Node node)
        {
            Node parent = node.ParentNode;

            if (parent == null)
            {
                throw new Exception();
            }

            SetBoundary(parent, node.Index + 1, true); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setEndBefore")]
        public void SetEndBefore(Node node)
        {
            Node parent = node.ParentNode;

            if (parent == null)
            {
                throw new Exception();
            }

            SetBoundary(parent, node.Index, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("setEndAfter")]
        public void SetEndAfter(Node node)
        {
            Node parent = node.ParentNode;

            if (parent == null)
            {
                throw new Exception();
            }

            SetBoundary(parent, node.Index + 1, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toStart"></param>
        [ES("collapse")]
        public void Collapse(bool toStart = false)
        {
            if (toStart)
            {
                _end = _start;
            }
            else
            {
                _start = _end;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("selectNode")]
        public void SelectNode(Node node)
        {
            Node parent = node.ParentNode;

            if (node == null)
            {
                throw new Exception();
            }

            int index = node.Index;

            _start = new Boundary { Node = parent, Offset = index };
            _end = new Boundary { Node = parent, Offset = index + 1 };
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        [ES("selectNodeContents")]
        public void SelectNodeContents(Node node)
        {
            if (node.NodeType == NodeType.DocumentType)
            {
                throw new Exception();
            }

            int length = node.Length;

            _start = new Boundary { Node = node, Offset = 0 };
            _end = new Boundary { Node = node, Offset = length };
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
            if (Root != sourceRange.Root)
            {
                throw new Exception();
            }

            Boundary thisPoint;
            Boundary otherPoint;

            switch (how)
            {
                case RangeType.StartToStart:
                    thisPoint = _start;
                    otherPoint = sourceRange._start;
                    break;
                case RangeType.StartToEnd:
                    thisPoint = _end;
                    otherPoint = sourceRange._start;
                    break;
                case RangeType.EndToEnd:
                    thisPoint = _end;
                    otherPoint = sourceRange._end;
                    break;
                case RangeType.EndToStart:
                    thisPoint = _start;
                    otherPoint = sourceRange._end;
                    break;
                default:
                    throw new Exception();
            }

            if (thisPoint < otherPoint)
            {
                return -1;
            }
            else if (thisPoint > otherPoint)
            {
                return 1;
            }
            else
            {
                return 0;
            }
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

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="offset"></param>
        /// <param name="setTheStart"></param>
        private void SetBoundary(Node node, int offset, bool setTheStart)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.NodeType == NodeType.DocumentType)
            {
                throw new Exception();
            }

            if (offset > node.Length)
            {
                throw new Exception();
            }

            Boundary bp = new Boundary
            {
                Node = node,
                Offset = offset
            };

            if (setTheStart)
            {
                if (bp > _end)
                {
                    _end = bp;
                }

                _start = bp;
            }
            else
            {
                if (bp < _start)
                {
                    _start = bp;
                }

                _end = bp;
            }
        }

        #endregion

        #region Boundary Struct

        /// <summary>
        /// 
        /// </summary>
        internal struct Boundary : IComparable<Boundary>, IEquatable<Boundary>
        {
            public Node Node;
            public int Offset;

            public static bool operator <(Boundary obj1, Boundary obj2)
            {
                return obj1.CompareTo(obj2) < 0;
            }

            public static bool operator >(Boundary obj1, Boundary obj2)
            {
                return obj1.CompareTo(obj2) > 0;
            }

            public static bool operator <=(Boundary obj1, Boundary obj2)
            {
                return obj1.CompareTo(obj2) <= 0;
            }

            public static bool operator >=(Boundary obj1, Boundary obj2)
            {
                return obj1.CompareTo(obj2) >= 0;
            }

            public static bool operator !=(Boundary obj1, Boundary obj2)
            {
                return obj1.CompareTo(obj2) != 0;
            }

            public static bool operator ==(Boundary obj1, Boundary obj2)
            {
                return obj1.CompareTo(obj2) != 0;
            }

            public int CompareTo(Boundary other)
            {
                if (Node == other.Node)
                {
                    if (Offset > other.Offset)
                    {
                        return 1;
                    }
                    else if (Offset < other.Offset)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                return -1;
            }

            public bool Equals(Boundary other)
            {
                return CompareTo(other) == 0;
            }

            public override bool Equals(object obj)
            {
                return (obj is Boundary) && (CompareTo((Boundary)obj) == 0);
            }

            public override int GetHashCode()
            {
                int hashCode = -2042807521;
                hashCode = hashCode * -1521134295 + base.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<Node>.Default.GetHashCode(Node);
                hashCode = hashCode * -1521134295 + Offset.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
