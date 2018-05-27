using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
{
    internal class ProcessingInstruction : CharacterData, IProcessingInstruction
    {
        /// <summary>
        /// 
        /// </summary>
        public string Target { get; }
    }
}
