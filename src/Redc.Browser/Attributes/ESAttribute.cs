using System;

namespace Redc.Browser.Attributes
{
    /// <summary>
    /// Specifies that it should be used in EcmaScript Bindings.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    internal sealed class ESAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ESAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
    }
}
