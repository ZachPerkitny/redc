using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Traversal
{
    /// <summary>
    /// 
    /// </summary>
    [ES("NodeFilter")]
    public enum FilterResult
    {
        [ES("FILTER_ACCEPT")]
        FilterAccept = 1,

        [ES("FILTER_REJECT")]
        FilterReject = 2,

        [ES("FILTER_SKIP")]
        FilterSkip = 3
    }
}
