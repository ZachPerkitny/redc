using System.Collections.Generic;
using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Sets.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("NodeList")]
    public interface INodeList : IEnumerable<INode>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("item")]
        INode this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        int Length { get; }
    }
}
