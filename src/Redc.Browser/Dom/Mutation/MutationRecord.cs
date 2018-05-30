using Redc.Browser.Attributes;
using Redc.Browser.Dom.Collections;

namespace Redc.Browser.Dom.Mutation
{
    /// <summary>
    /// 
    /// </summary>
    [ES("MutationRecord")]
    public class MutationRecord
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("type")]
        public string Type { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("target")]
        public Node Target { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("addedNodes")]
        public NodeList AddedNodes { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("removedNodes")]
        public NodeList RemovedNodes { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("previousSibling")]
        public Node PreviousSibling { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("nextSibling")]
        public Node NextSibling { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("attributeName")]
        public string AttributeName { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("attributeNamespace")]
        public string AttributeNamespace { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("oldValue")]
        public string OldValue { get; }
    }
}
