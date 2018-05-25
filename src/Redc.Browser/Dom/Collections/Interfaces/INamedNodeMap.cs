using Redc.Browser.Attributes;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom.Collections.Interfaces
{
    [ES("NamedNodeMap")]
    internal interface INamedNodeMap
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
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("getNamedItem")]
        INode GetNamedItem(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [ES("setNamedItem")]
        INode SetNamedItem(INode arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ES("removeNamedItem")]
        INode RemoveNamedItem(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespaceUri"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("getNamedItemNS")]
        INode GetNamedItemNS(string namespaceUri, string localName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [ES("setNamedItemNS")]
        INode SetNamedItemNS(INode arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespaceUri"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        [ES("removeNamedItem")]
        INode RemoveNamedItemNS(string namespaceUri, string localName);
    }
}
