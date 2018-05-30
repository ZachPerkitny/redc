using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Collections
{
    /// <summary>
    /// 
    /// </summary>
    [ES("NamedNodeMap")]
    public class NamedNodeMap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [ES("item")]
        public Attr this[int index]
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("getNamedItem")]
        public Attr GetNamedItem(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [ES("setNamedItem")]
        public Attr SetNamedItem(Node arg)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("removeNamedItem")]
        public Attr RemoveNamedItem(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespaceUri"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getNamedItemNS")]
        public Attr GetNamedItemNS(string namespaceUri, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [ES("setNamedItemNS")]
        public Attr SetNamedItemNS(Node arg)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespaceUri"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("removeNamedItem")]
        public Attr RemoveNamedItemNS(string namespaceUri, string localName)
        {
            throw new System.NotImplementedException();
        }
    }
}
