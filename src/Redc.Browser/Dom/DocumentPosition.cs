using System;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    [ES("Node")]
    public enum DocumentPosition : ushort
    {
        [ES("DOCUMENT_POSITION_DISCONNECTED")]
        DocumentPositionDisconnected = 0x01,

        [ES("DOCUMENT_POSITION_PRECEDING")]
        DocumentPositionPreceding = 0x02,

        [ES("DOCUMENT_POSITION_FOLLOWING")]
        DocumentPositionFollowing = 0x04,

        [ES("DOCUMENT_POSITION_CONTAINS")]
        DocumentPositionContains = 0x08,

        [ES("DOCUMENT_POSITION_CONTAINED_BY")]
        DocumentPositionContainedBy = 0x10,

        [ES("DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC")]
        DocumentPositionImplementationSpecific = 0x20
    }
}
