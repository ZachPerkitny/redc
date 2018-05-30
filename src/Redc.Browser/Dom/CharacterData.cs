using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Abstract class implemented by Text, Comment and ProcessingInstruction nodes
    /// </summary>
    [ES("CharacterData")]
    public abstract class CharacterData : Node
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <param name="nodeType"></param>
        public CharacterData(Document document, string name, NodeType nodeType)
            : base(document, name, nodeType) { }

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("data")]
        public string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        public int Length { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        [ES("appendData")]
        public void AppendData(string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        [ES("deleteData")]
        public void DeleteData(int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        [ES("insertData")]
        public void InsertData(int offset, string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="data"></param>
        [ES("replaceData")]
        public void ReplaceData(int offset, int count, int data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [ES("substringData")]
        public string SubstringData(int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
