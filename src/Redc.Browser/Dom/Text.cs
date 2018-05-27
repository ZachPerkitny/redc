using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
{
    internal class Text : CharacterData, IText
    {
        /// <summary>
        /// 
        /// </summary>
        public string WholeText { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IText SplitText(int offset)
        {
            throw new System.NotImplementedException();
        }
    }
}
