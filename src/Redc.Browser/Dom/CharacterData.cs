using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Abstract class implemented by Text, Comment and ProcessingInstruction nodes
    /// </summary>
    internal abstract class CharacterData : Node, ICharacterData
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Length { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void AppendData(string data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public void DeleteData(int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="data"></param>
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
        public string SubstringData(int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
