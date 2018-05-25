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
        event EventHandler Abort;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Blur;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Cancel;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler CanPlay;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Change;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Click;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Close;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler CueChange;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DblClick;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Drag;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DragEnd;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DragEnter;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DragExit;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DragLeave;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DragOver;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DragStart;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Drop;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler DurationChange;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Emptied;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Ended;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Error;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Focus;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Input;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Invalid;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Keydown;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Keypress;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Keyup;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Load;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler LoadedData;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler LoadedMetaData;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler LoadStart;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler MouseDown;

        /// <summary>
        /// 
        /// </summary>
        [LenientThis]
        event EventHandler MouseEnter;

        /// <summary>
        /// 
        /// </summary>
        [LenientThis]
        event EventHandler MouseLeave;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler MouseMove;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler MouseOut;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler MouseOver;
        
        /// <summary>
        /// 
        /// </summary>
        event EventHandler MouseUp;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Wheel;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Pause;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Play;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Playing;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Progress;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler RateChange;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Reset;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Resize;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Scroll;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Seeked;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Seeking;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Select;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Show;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Stalled;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Submit;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Suspend;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler TimeUpdate;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Toggle;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler VolumeChange;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Waiting;
    }
}
