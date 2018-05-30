using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Abstract class implemented by Text, Comment and ProcessingInstruction nodes
    /// </summary>
    [ES("CharacterData")]
    public abstract class CharacterData : Node
    {
        private string _data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public CharacterData(Document owner)
            : base(owner)
        {
            _data = string.Empty;
        }

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [ES("data")]
        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }

                _data = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("length")]
        public override int Length
        {
            get { return _data.Length; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        [ES("appendData")]
        public void AppendData(string data)
        {
            ReplaceData(Length, 0, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        [ES("deleteData")]
        public void DeleteData(int offset, int count)
        {
            ReplaceData(offset, count, string.Empty);
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
        public void ReplaceData(int offset, int count, string data)
        {
            if (offset > Length)
            {
                throw new System.Exception();
            }

            if (offset + count > Length)
            {
                count = Length - offset;
            }

            // TODO Ranges and Mutation stuff
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
            if (offset > Length)
            {
                throw new System.Exception();
            }

            if (offset + count > Length)
            {
                return _data.Substring(offset);
            }

            return _data.Substring(offset, count);
        }

        #endregion
    }
}
