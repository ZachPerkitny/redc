using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// Type of Node
    /// </summary>
    [ES("Node")]
    public enum NodeType
    {
        [ES("ELEMENT_NODE")]
        Element = 1,

        [ES("ATTRIBUTE_NODE")]
        Attribute = 2,

        [ES("TEXT_NODE")]
        Text = 3,

        [ES("CDATA_SECTION_NODE")]
        CDataSection = 4,

        [ES("ENTITY_REFERENCE_NODE")]
        EntityReference = 5,

        [ES("ENTITY_NODE")]
        Entity = 6,

        [ES("PROCESSING_INSTRUCTION_NODE")]
        ProcessingInstruction = 7,

        [ES("COMMENT_NODE")]
        Comment = 8,

        [ES("DOCUMENT_NODE")]
        Document = 9,

        [ES("DOCUMENT_TYPE_NODE")]
        DocumentType = 10,

        [ES("DOCUMENT_FRAGMENT_NODE")]
        DocumentFragment = 11,

        [ES("NOTATION_NODE")]
        Notation = 12
    }
}
