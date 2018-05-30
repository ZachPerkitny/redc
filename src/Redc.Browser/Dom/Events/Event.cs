using System;
using System.Collections.Generic;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Events
{
    [ES("Event")]
    public class Event : EventArgs
    {
        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bubbles"></param>
        /// <param name="cancelable"></param>
        [ESConstructor]
        public Event(string type, bool bubbles = false, bool cancelable = false)
        {
            EventPhase = EventPhase.None;
            Flags = EventFlags.None;
            TimeStamp = DateTime.Now;

            InitEvent(type, bubbles, cancelable);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        internal EventFlags Flags { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("type")]
        public string Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("target")]
        public EventTarget Target { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("currentTarget")]
        public EventTarget CurrentTarget { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("eventPhase")]
        public EventPhase EventPhase { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("bubbles")]
        public bool Bubbles { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("cancelable")]
        public bool Cancelable { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("defaultPrevented")]
        public bool DefaultPrevented
        {
            get
            {
                return (Flags & EventFlags.Canceled) == EventFlags.Canceled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("isTrusted")]
        public bool IsTrusted { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [ES("timeStamp")]
        public DateTime TimeStamp { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        [ES("stopPropagation")]
        public void StopPropagation()
        {
            Flags |= EventFlags.StopPropagation;
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("stopImmediatePropagation")]
        public void StopImmediatePropagation()
        {
            Flags |= EventFlags.StopImmediatePropagation;
        }

        /// <summary>
        /// 
        /// </summary>
        [ES("preventDefault")]
        public void PreventDefault()
        {
            if (Cancelable)
            {
                Flags |= EventFlags.Canceled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bubbles"></param>
        /// <param name="cancelable"></param>
        [ES("initEvent")]
        public void InitEvent(string type, bool bubbles, bool cancelable)
        {
            if ((Flags & EventFlags.Dispatch) == EventFlags.Dispatch)
            {
                Flags |= EventFlags.Initialized;
                Flags &= ~(EventFlags.StopPropagation | EventFlags.StopImmediatePropagation | EventFlags.Canceled);
                IsTrusted = false;
                Target = null;
                Type = type;
                Bubbles = bubbles;
                Cancelable = cancelable;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal bool Dispatch(EventTarget target)
        {
            Flags |= EventFlags.Dispatch;
            Target = target;

            List<EventTarget> eventPath = new List<EventTarget>();
            if (target is Node node)
            {
                while (node.ParentNode != null)
                {
                    eventPath.Add(node.ParentNode);
                    node = node.ParentNode;
                }
            }

            EventPhase = EventPhase.CapturingPhase;

            for (int i = eventPath.Count - 1; i >= 0; i--)
            {
                if ((Flags & EventFlags.StopPropagation) != EventFlags.StopPropagation)
                {
                    eventPath[i].InvokeEventListeners(this);
                }
            }

            EventPhase = EventPhase.AtTarget;

            if ((Flags & EventFlags.StopPropagation) != EventFlags.StopPropagation)
            {
                target.InvokeEventListeners(this);
            }

            if (Bubbles)
            {
                EventPhase = EventPhase.BubblingPhase;
                for (int i = 0; i < eventPath.Count; i++)
                {
                    if ((Flags & EventFlags.StopPropagation) != EventFlags.StopPropagation)
                    {
                        eventPath[i].InvokeEventListeners(this);
                    }
                }
            }

            Flags &= ~EventFlags.Dispatch;
            EventPhase = EventPhase.None;
            CurrentTarget = null;

            return (Flags & EventFlags.Canceled) != EventFlags.Canceled;
        }

        #endregion
    }
}
