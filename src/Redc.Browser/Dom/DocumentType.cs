using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
{
    internal class DocumentType : Node, IDocumentType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DocumentType(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string PublicID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SystemID { get; set; }
    }
}
