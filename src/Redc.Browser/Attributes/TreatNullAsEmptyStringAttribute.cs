using System;

namespace Redc.Browser.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false)]
    internal sealed class TreatNullAsEmptyStringAttribute : Attribute { }
}
