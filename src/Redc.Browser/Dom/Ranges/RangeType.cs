using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Ranges
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Range")]
    public enum RangeType : ushort
    {
        [ES("START_TO_START")]
        StartToStart = 0,

        [ES("START_TO_END")]
        StartToEnd = 1,

        [ES("END_TO_END")]
        EndToEnd = 2,

        [ES("END_TO_START")]
        EndToStart = 3
    }
}
