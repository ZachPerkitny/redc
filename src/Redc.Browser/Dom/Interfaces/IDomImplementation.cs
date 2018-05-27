using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("DOMImplementation")]
    public interface IDomImplementation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qualifiedName"></param>
        /// <param name="publicId"></param>
        /// <param name="systemId"></param>
        /// <returns></returns>
        IDocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="qualifiedName"></param>
        /// <param name="doctype"></param>
        /// <returns></returns>
        IXmlDocument CreateDocument(string @namespace, string qualifiedName, IDocumentType doctype);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        IDocument CreateHtmlDocument(string title);
    }
}
