using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Comment")]
    public class Comment : CharacterData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public Comment(Document owner)
            : base(owner) { }

        /// <summary>
        /// 
        /// </summary>
        public override NodeType NodeType
        {
            get { return NodeType.Comment; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NodeName
        {
            get { return "#comment"; }
        }
    }
}
