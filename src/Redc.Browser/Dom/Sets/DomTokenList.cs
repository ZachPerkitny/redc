using System.Collections;
using System.Collections.Generic;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Sets
{
    /// <summary>
    /// 
    /// </summary>
    [ES("DomTokenList")]
    public class DomTokenList : IEnumerable<string>
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        public int Length { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("item")]
        public string this[int index]
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [ES("contains")]
        public bool Contains(string token)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        [ES("add")]
        public void Add(params string[] tokens)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        [ES("remove")]
        public void Remove(params string[] tokens)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        [ES("toggle")]
        public bool Toggle(string token, bool force = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator()
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
