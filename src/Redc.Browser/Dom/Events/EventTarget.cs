using Redc.Browser.Dom.Events.Interfaces;

namespace Redc.Browser.Dom.Events
{
    /// <summary>
    /// 
    /// </summary>
    internal class EventTarget : IEventTarget
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="capture"></param>
        public void AddEventListener(string type, EventListener callback, bool capture = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool DispatchEvent(IEvent @event)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="capture"></param>
        public void RemoveEventListener(string type, EventListener callback, bool capture = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
