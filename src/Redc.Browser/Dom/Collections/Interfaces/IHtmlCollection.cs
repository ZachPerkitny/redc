using System.Collections.Generic;
using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Collections.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("HTMLCollection")]
    public interface IHtmlCollection : IEnumerable<IElement>
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        int Length { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("item")]
        IElement this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("namedItem")]
        IElement this[string name] { get; }
    }
}
