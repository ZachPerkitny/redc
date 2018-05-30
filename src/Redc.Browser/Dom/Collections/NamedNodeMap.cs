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
        public Node this[int index]
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("getNamedItem")]
        public Node GetNamedItem(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [ES("setNamedItem")]
        public Node SetNamedItem(Node arg)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("removeNamedItem")]
        public Node RemoveNamedItem(string name)
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
        public Node GetNamedItemNS(string namespaceUri, string localName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [ES("setNamedItemNS")]
        public Node SetNamedItemNS(Node arg)
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
        public Node RemoveNamedItemNS(string namespaceUri, string localName)
        {
            throw new System.NotImplementedException();
        }
    }
}
