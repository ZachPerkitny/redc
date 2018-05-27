using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("ProcessingInstruction")]
    public interface IProcessingInstruction : ICharacterData
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("target")]
        string Target { get; }
    }
}
