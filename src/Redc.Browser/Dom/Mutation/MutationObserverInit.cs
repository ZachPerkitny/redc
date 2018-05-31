using System.Collections.Generic;

namespace Redc.Browser.Dom.Mutation
{
    /// <summary>
    /// 
    /// </summary>
    public class MutationObserverInit
    {
        public bool ChildList { get; set; } = false;

        public bool? Attributes { get; set; }

        public bool? CharacterData { get; set; }

        public bool Subtree { get; set; } = false;

        public bool? AttributeOldValue { get; set; }

        public bool? CharacterDataOldValue { get; set; }

        public IEnumerable<string> AttributeFilter { get; set; }
    }
}
