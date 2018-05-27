using System;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Traversal
{
    [Flags]
    [ES("NodeFilter")]
    public enum FilterSettings : ulong
    {
        [ES("SHOW_ALL")]
        ShowAll = 0xFFFFFFFF,

        [ES("SHOW_ELEMENT")]
        ShowElement = 0x1,

        [ES("SHOW_ATTRIBUTE")]
        ShowAttribute = 0x2,

        [ES("SHOW_TEXT")]
        ShowText = 0x4,

        [ES("SHOW_CDATA_SECTION")]
        ShowCDataSection = 0x8,

        [ES("SHOW_ENTITY_REFERENCE")]
        ShowEntityReference = 0x10,

        [ES("SHOW_ENTITY")]
        ShowEntity = 0x20,

        [ES("SHOW_PROCESSING_INSTRUCTION ")]
        ShowProcessingInstruction = 0x40,

        [ES("SHOW_COMMENT ")]
        ShowComment = 0x80,

        [ES("SHOW_DOCUMENT ")]
        ShowDoucment = 0x100,

        [ES("SHOW_DOCUMENT_TYPE ")]
        ShowDocumentType = 0x200,

        [ES("SHOW_DOCUMENT_FRAGMENT ")]
        ShowDocumentFragment = 0x400,

        [ES("SHOW_NOTATION")]
        ShowNotation = 0x800
    }
}
