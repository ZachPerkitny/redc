using System.Collections;
using System.Collections.Generic;
using Redc.Browser.Dom.Collections.Interfaces;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Collections
{
    /// <summary>
    /// Collection of elements
    /// </summary>
    internal class HtmlCollection : IHtmlCollection
    {
        #region Fields

        private readonly List<IElement> _elements;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        public HtmlCollection(IEnumerable<IElement> elements)
        {
            _elements = new List<IElement>(elements);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Length
        {
            get { return _elements.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IElement this[int index]
        {
            get { return _elements[index]; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IElement this[string name]
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<IElement> Elements
        {
            get { return _elements.AsReadOnly(); }
        }

        #endregion

        #region IEnumerable Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IElement> GetEnumerator()
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
