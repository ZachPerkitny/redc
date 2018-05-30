using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    [ES("Attr")]
    public class Attr
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localName"></param>
        /// <param name="value"></param>
        /// <param name="namespace"></param>
        /// <param name="namespacePrefix"></param>
        public Attr(string localName, string value, string @namespace = null, string namespacePrefix = null)
            : this(localName, localName, value, @namespace, namespacePrefix) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="localName"></param>
        /// <param name="value"></param>
        /// <param name="namespace"></param>
        /// <param name="namespacePrefix"></param>
        public Attr(string name, string localName, string value, string @namespace = null, string namespacePrefix = null)
        {
            Name = name;
            LocalName = localName;
            Value = value;
            NamespaceUri = @namespace;
            Prefix = namespacePrefix;
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("namespaceURI")]
        public string NamespaceUri { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("prefix")]
        public string Prefix { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("localName")]
        public string LocalName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("name")]
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("value")]
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("specified")]
        public bool Specified
        {
            get { return true; }
        }
    }
}
