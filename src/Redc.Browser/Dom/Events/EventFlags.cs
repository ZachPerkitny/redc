using System;

namespace Redc.Browser.Dom.Events
{
    [Flags]
    public enum EventFlags
    {
        None = 0x0,
        StopPropagation = 0x1,
        StopImmediatePropagation = 0x2,
        Canceled = 0x4,
        Initialized = 0x8,
        Dispatch = 0x16
    }
}
