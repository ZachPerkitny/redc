using System.Collections;
using System.Collections.Generic;

namespace Redc.Browser.Dom.Collections
{
    /// <summary>
    /// Collection of elements
    /// </summary>
    internal class HTMLCollection : IEnumerable<Element>
    {
        #region Fields

        private readonly List<Element> _elements;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        public HTMLCollection(IEnumerable<Element> elements)
        {
            _elements = new List<Element>(elements);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Element> Elements
        {
            get { return _elements.AsReadOnly(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Element this[int index]
        {
            get { return _elements[index]; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Element this[string name]
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        #region IEnumerable Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Element> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        #endregion
    }
}
