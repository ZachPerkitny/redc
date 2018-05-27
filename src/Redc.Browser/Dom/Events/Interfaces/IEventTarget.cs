using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Events.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("EventTarget")]
    public interface IEventTarget
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="capture"></param>
        [ES("addEventListener")]
        void AddEventListener(string type, EventListener callback, bool capture = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="capture"></param>
        [ES("removeEventListener")]
        void RemoveEventListener(string type, EventListener callback, bool capture = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [ES("dispatchEvent")]
        bool DispatchEvent(IEvent @event);
    }
}
