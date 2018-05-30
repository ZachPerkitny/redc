using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    [ES("Attr")]
    public class Attr
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
