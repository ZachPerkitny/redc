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
        None = 0x0,

        [ES("DOCUMENT_POSITION_DISCONNECTED")]
        Disconnected = 0x01,

        [ES("DOCUMENT_POSITION_PRECEDING")]
        Preceding = 0x02,

        [ES("DOCUMENT_POSITION_FOLLOWING")]
        Following = 0x04,

        [ES("DOCUMENT_POSITION_CONTAINS")]
        Contains = 0x08,

        [ES("DOCUMENT_POSITION_CONTAINED_BY")]
        ContainedBy = 0x10,

        [ES("DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC")]
        ImplementationSpecific = 0x20
    }
}
