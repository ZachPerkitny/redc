using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [ES("DocumentType")]
    public class DocumentType : Node
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        public DocumentType(Document owner, string name)
            : base(owner, name, NodeType.DocumentType) { }

        /// <summary>
        /// 
        /// </summary>
        [ES("name")]
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("publicId")]
        public string PublicID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("systemId")]
        public string SystemID { get; set; }
    }
}
