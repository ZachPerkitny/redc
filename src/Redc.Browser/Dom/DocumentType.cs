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
        /// <param name="publicID"></param>
        /// <param name="systemID"></param>
        public DocumentType(Document owner, string name, string publicID = "", string systemID = "")
            : base(owner)
        {
            Name = name;
            PublicID = publicID;
            SystemID = systemID;
        }

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

        /// <summary>
        /// 
        /// </summary>
        public override NodeType NodeType
        {
            get { return NodeType.DocumentType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NodeName
        {
            get { return Name; }
        }
    }
}
