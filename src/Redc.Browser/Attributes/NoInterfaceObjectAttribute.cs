using System;

namespace Redc.Browser.Attributes
{
    /// <summary>
    /// Indicates that an interface object will not exist for 
    /// the interface in the ECMAScript binding.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    internal sealed class NoInterfaceObjectAttribute : Attribute { }
}
