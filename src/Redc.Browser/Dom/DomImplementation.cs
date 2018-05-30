using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [ES("DOMImplementation")]
    public class DomImplementation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qualifiedName"></param>
        /// <param name="publicId"></param>
        /// <param name="systemId"></param>
        /// <returns></returns>
        [ES("createDocumentType")]
        public DocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="qualifiedName"></param>
        /// <param name="doctype"></param>
        /// <returns></returns>
        [ES("createDocument")]
        public XmlDocument CreateDocument(string @namespace, string qualifiedName, DocumentType doctype)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [ES("createHtmlDocument")]
        public Document CreateHtmlDocument(string title)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("hasFeature")]
        public bool HasFeature()
        {
            return true;
        }
    }
}
