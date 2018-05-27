using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Text")]
    public interface IText : ICharacterData
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("wholeText")]
        string WholeText { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        [ES("splitText")]
        IText SplitText(int offset);
    }
}
