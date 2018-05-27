using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
{
    internal class Attr : IAttr
    {
        /// <summary>
        /// 
        /// </summary>
        public string NamespaceUri { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// 
        /// </summary>
        public string LocalName { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Specified
        {
            get { return true; }
        }
    }
}
