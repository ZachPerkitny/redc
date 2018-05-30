using Redc.Browser.Attributes;
using System.Collections.Generic;

namespace Redc.Browser.Dom.Mutation
{
    /// <summary>
    /// 
    /// </summary>
    [ES("MutationObserver")]
    public class MutationObserver
    {
        private readonly MutationCallback _callback;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        [ESConstructor]
        public MutationObserver(MutationCallback callback)
        {
            _callback = callback;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="options"></param>
        [ES("observe")]
        void Observe(Node target, MutationObserverInit options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [ES("disconnect")]
        void Disconnect()
        {

        }
    }
}
