using System.Collections.Generic;
using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Collections.Interfaces
{
    [ES("NodeList")]
    internal interface INodeList : IEnumerable<INode>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("this")]
        INode this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        int Length { get; }
    }
}
