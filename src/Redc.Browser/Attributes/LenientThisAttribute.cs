using System;

namespace Redc.Browser.Attributes
{
    /// <summary>
    /// Indicates that invocations of the attribute’s getter or setter 
    /// with a this value that is not an object that implements the 
    /// interface on which the attribute appears will be ignored.
    /// </summary>
    [AttributeUsage(AttributeTargets.Event |AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    internal sealed class LenientThisAttribute : Attribute { }
}
