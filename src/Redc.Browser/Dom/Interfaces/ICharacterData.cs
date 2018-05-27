using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("CharacterData")]
    public interface ICharacterData : INode
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("data")]
        string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        int Length { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [ES("substringData")]
        string SubstringData(int offset, int count);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        [ES("appendData")]
        void AppendData(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        [ES("insertData")]
        void InsertData(int offset, string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        [ES("deleteData")]
        void DeleteData(int offset, int count);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="data"></param>
        [ES("replaceData")]
        void ReplaceData(int offset, int count, int data);
    }
}
