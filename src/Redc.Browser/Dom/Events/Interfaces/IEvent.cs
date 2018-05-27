using System;
using Redc.Browser.Attributes;

namespace Redc.Browser.Dom.Events.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    [ES("Event")]
    public interface IEvent
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("type")]
        string Type { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("target")]
        IEventTarget Target { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("currentTarget")]
        IEventTarget CurrentTarget { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("eventPhase")]
        EventPhase EventPhase { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("bubbles")]
        bool Bubbles { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("cancelable")]
        bool Cancelable { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("defaultPrevented")]
        bool DefaultPrevented { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("isTrusted")]
        bool IsTrusted { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("timeStamp")]
        DateTime TimeStamp { get; }

        /// <summary>
        /// 
        /// </summary>
        [ES("stopPropagation")]
        void StopPropagation();

        /// <summary>
        /// 
        /// </summary>
        [ES("stopImmediatePropagation")]
        void StopImmediatePropagation();

        /// <summary>
        /// 
        /// </summary>
        [ES("preventDefault")]
        void PreventDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bubbles"></param>
        /// <param name="cancelable"></param>
        [ES("initEvent")]
        void InitEvent(string type, bool bubbles, bool cancelable);
    }
}
