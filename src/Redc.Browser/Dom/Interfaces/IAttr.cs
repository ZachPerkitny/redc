using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    [ES("Attr")]
    public interface IAttr
    {
        /// <summary>
        /// 
        /// </summary>
        string NamespaceUri { get; }

        /// <summary>
        /// 
        /// </summary>
        string Prefix { get; }

        /// <summary>
        /// 
        /// </summary>
        string LocalName { get; }

        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool Specified { get; }
    }
}
