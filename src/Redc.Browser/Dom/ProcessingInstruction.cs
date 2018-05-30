using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [ES("ProcessingInstruction")]
    public class ProcessingInstruction : CharacterData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public ProcessingInstruction(Document owner)
            : base(owner) { }

        /// <summary>
        /// 
        /// </summary>
        [ES("target")]
        public string Target { get; }

        /// <summary>
        /// 
        /// </summary>
        public override NodeType NodeType
        {
            get { return NodeType.ProcessingInstruction; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NodeName
        {
            get { return Target; }
        }
    }
}
