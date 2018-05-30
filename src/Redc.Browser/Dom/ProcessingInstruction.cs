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
        [ES("target")]
        public string Target { get; }
    }
}
