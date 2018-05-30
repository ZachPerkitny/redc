using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    [ES("Text")]
    public class Text : CharacterData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public Text(Document owner)
            : base(owner) { }

        /// <summary>
        /// 
        /// </summary>
        [ES("wholeText")]
        public string WholeText { get; }

        /// <summary>
        /// 
        /// </summary>
        public override NodeType NodeType
        {
            get { return NodeType.Text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string NodeName
        {
            get { return "#text"; }
        }

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
