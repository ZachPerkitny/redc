using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [ES("DocumentFragment")]
    public class DocumentFragment : Node
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public DocumentFragment(Document owner)
            : base(owner, "#document-fragment", NodeType.DocumentFragment) { }
    }
}
