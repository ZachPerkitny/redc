using System.Collections.Generic;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Collections.Interfaces
{
    [ES("DomTokenList")]
    internal interface IDomTokenList : IEnumerable<string>
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
        string this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [ES("contains")]
        bool Contains(string token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        [ES("add")]
        void Add(params string[] tokens);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        [ES("remove")]
        void Remove(params string[] tokens);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        [ES("toggle")]
        bool Toggle(string token, bool force = false);
    }
}
