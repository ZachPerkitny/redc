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
        ElementNode = 1,

        [ES("ATTRIBUTE_NODE")]
        AttributeNode = 2,

        [ES("TEXT_NODE")]
        TextNode = 3,

        [ES("CDATA_SECTION_NODE")]
        CDataSectionNode = 4,

        [ES("ENTITY_REFERENCE_NODE")]
        EntityReferenceNode = 5,

        [ES("ENTITY_NODE")]
        EntityNode = 6,

        [ES("PROCESSING_INSTRUCTION_NODE")]
        ProcessingInstructionNode = 7,

        [ES("COMMENT_NODE")]
        CommentNode = 8,

        [ES("DOCUMENT_NODE")]
        DocumentNode = 9,

        [ES("DOCUMENT_TYPE_NODE")]
        DocumentTypeNode = 10,

        [ES("DOCUMENT_FRAGMENT_NODE")]
        DocumentFragmentNode = 11,

        [ES("NOTATION_NODE")]
        NotationNode = 12
    }
}
