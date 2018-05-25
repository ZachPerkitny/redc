using Redc.Browser.Dom.Events;
using Redc.Browser.Dom.Interfaces;

namespace Redc.Browser.Dom
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
        public void AddEventListener(string type, EventHandler callback, bool capture = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool DispatchEvent(Event @event)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="capture"></param>
        public void RemoveEventListener(string type, EventHandler callback, bool capture = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
