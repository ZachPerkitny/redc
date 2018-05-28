using System.Collections.Generic;
using Redc.Browser.Dom.Events.Interfaces;

namespace Redc.Browser.Dom.Events
{
    /// <summary>
    /// 
    /// </summary>
    internal class EventTarget : IEventTarget
    {
        private readonly List<EventListener> _listeners;

        /// <summary>
        /// 
        /// </summary>
        public EventTarget()
        {
            _listeners = new List<EventListener>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="capture"></param>
        public void AddEventListener(string type, EventHandler callback, bool capture = false)
        {
            if (callback != null)
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool DispatchEvent(Event @event)
        {
            if ((@event.Flags & EventFlags.Dispatch) == EventFlags.Dispatch ||
                (@event.Flags & EventFlags.Initialized) != EventFlags.Initialized)
            {
                throw new System.Exception(); // todo: exception
            }

            @event.IsTrusted = false;
            return @event.Dispatch(this);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void InvokeEventListeners(Event @event)
        {
            // Reference: https://www.w3.org/TR/2015/REC-dom-20151119/#concept-event-listener-invoke
            EventListener[] listeners = _listeners.ToArray();
            @event.CurrentTarget = this;

            foreach (EventListener listener in _listeners)
            {
                if ((@event.Flags & EventFlags.StopImmediatePropagation) == EventFlags.StopImmediatePropagation)
                {
                    return;
                }

                if (@event.Type != listener.Type || (@event.EventPhase == EventPhase.CapturingPhase && !listener.Capture) || 
                    (@event.EventPhase == EventPhase.BubblingPhase && listener.Capture))
                {
                    continue;
                }

                listener.Callback(this, @event);
            }
        }
    }
}
