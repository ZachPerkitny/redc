using System;

namespace Redc.Browser.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false)]
    internal sealed class SameObjectAttribute : Attribute { }
}
