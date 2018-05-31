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
        private readonly Queue<MutationRecord> _recordQueue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        [ESConstructor]
        public MutationObserver(MutationCallback callback)
        {
            _callback = callback;
            _recordQueue = new Queue<MutationRecord>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="options"></param>
        [ES("observe")]
        public void Observe(Node target, MutationObserverInit options)
        {
            if ((options.AttributeOldValue != null || options.AttributeFilter != null) && options.Attributes == null)
            {
                options.Attributes = true;
            }

            if (options.CharacterDataOldValue != null && options.CharacterData == null)
            {
                options.CharacterData = true;
            }

            if (options.ChildList == false&& options.CharacterData == false)
            {
                throw new System.Exception();
            }

            if (options.AttributeOldValue == true && options.Attributes == false)
            {
                throw new System.Exception();
            }

            if (options.AttributeFilter != null && options.Attributes == false)
            {
                throw new System.Exception();
            }

            if (options.CharacterDataOldValue == true && options.CharacterData == false)
            {
                throw new System.Exception();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("disconnect")]
        public void Disconnect()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ES("takeRecords")]
        public IEnumerable<MutationRecord> TakeRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}
