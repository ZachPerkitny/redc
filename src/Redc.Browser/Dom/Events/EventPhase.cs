using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Events
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Event")]
    public enum EventPhase : ushort
    {
        [ES("NONE")]
        None = 0,

        [ES("CAPTURING_PHASE")]
        CapturingPhase = 1,

        [ES("AT_TARGET")]
        AtTarget = 2,

        [ES("BUBBLING_PHASE")]
        BubblingPhase = 3
    }
}
