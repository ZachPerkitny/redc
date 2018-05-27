using Redc.Browser.Attributes;
using Redc.Browser.Dom.Events;

namespace Redc.Browser.Html.Interfaces
{
    [NoInterfaceObject]
    internal interface IGlobalEventHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        event EventListener Abort;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Blur;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Cancel;

        /// <summary>
        /// 
        /// </summary>
        event EventListener CanPlay;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Change;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Click;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Close;

        /// <summary>
        /// 
        /// </summary>
        event EventListener CueChange;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DblClick;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Drag;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DragEnd;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DragEnter;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DragExit;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DragLeave;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DragOver;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DragStart;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Drop;

        /// <summary>
        /// 
        /// </summary>
        event EventListener DurationChange;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Emptied;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Ended;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Error;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Focus;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Input;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Invalid;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Keydown;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Keypress;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Keyup;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Load;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener LoadedData;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener LoadedMetaData;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener LoadStart;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener MouseDown;

        /// <summary>
        /// 
        /// </summary>
        [LenientThis]
        event EventListener MouseEnter;

        /// <summary>
        /// 
        /// </summary>
        [LenientThis]
        event EventListener MouseLeave;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener MouseMove;

        /// <summary>
        /// 
        /// </summary>
        event EventListener MouseOut;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener MouseOver;
        
        /// <summary>
        /// 
        /// </summary>
        event EventListener MouseUp;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Wheel;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Pause;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Play;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Playing;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Progress;

        /// <summary>
        /// 
        /// </summary>
        event EventListener RateChange;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Reset;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Resize;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Scroll;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Seeked;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Seeking;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Select;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Show;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Stalled;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Submit;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Suspend;

        /// <summary>
        /// 
        /// </summary>
        event EventListener TimeUpdate;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Toggle;

        /// <summary>
        /// 
        /// </summary>
        event EventListener VolumeChange;

        /// <summary>
        /// 
        /// </summary>
        event EventListener Waiting;
    }
}
