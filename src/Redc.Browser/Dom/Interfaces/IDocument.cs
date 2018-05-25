using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Document")]
    internal interface IDocument : INode
    {
        // [SameObject]
        // DOMImplementation Implementation { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("URL")]
        string Url { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("DocumentURI")]
        string DocumentUri { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("origin")]
        string Origin { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("compatMode")]
        string CompatabilityMode { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("characterSet")]
        string CharacterSet { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("contentType")]
        string ContentType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("documentType")]
        DocumentType DocumentType { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("documentElement")]
        IElement DocumentElement { get; }
    }
}
