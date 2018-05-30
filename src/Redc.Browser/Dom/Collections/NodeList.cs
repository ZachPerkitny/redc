using System.Collections;
using System.Collections.Generic;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Collections
{
    /// <summary>
    /// 
    /// </summary>
    [ES("NodeList")]
    public class NodeList : IEnumerable<Node>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("item")]
        public Node this[int index]
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        public int Length { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
