using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    [ES("Text")]
    public class Text : CharacterData
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("wholeText")]
        public string WholeText { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        [ES("splitText")]
        public Text SplitText(int offset)
        {
            throw new System.NotImplementedException();
        }
    }
}
