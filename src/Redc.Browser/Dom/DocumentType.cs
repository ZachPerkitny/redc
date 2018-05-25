namespace Redc.Browser.Dom
{
    internal class DocumentType : Node
    {
        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DocumentType(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string PublicID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SystemID { get; set; }

        #endregion
    }
}
