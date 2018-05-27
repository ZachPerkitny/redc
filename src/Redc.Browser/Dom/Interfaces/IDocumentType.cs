using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentType : INode
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("name")]
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("publicId")]
        string PublicID { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("systemId")]
        string SystemID { get; }
    }
}
