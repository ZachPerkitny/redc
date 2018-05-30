using System.Collections;
using System.Collections.Generic;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Collections
{
    /// <summary>
    /// Collection of elements
    /// </summary>
    [ES("HTMLCollection")]
    public class HtmlCollection : IEnumerable<Element>
    {
        #region Fields

        private readonly List<Element> _elements;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        public HtmlCollection(IEnumerable<Element> elements)
        {
            _elements = new List<Element>(elements);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        public int Length
        {
            get
            {
                return _elements.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("item")]
        public Element this[int index]
        {
            get
            {
                return _elements[index];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("namedItem")]
        public Element this[string name]
        {
            get
            {
                foreach (Element element in _elements)
                {
                    if (element.ID == name)
                    {
                        return element;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Element> Elements
        {
            get { return _elements.AsReadOnly(); }
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
