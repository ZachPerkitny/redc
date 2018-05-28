using Redc.Browser.Attributes;
using Redc.Browser.Dom.Events;

namespace Redc.Browser.Html.Interfaces
{
    [ES("GlobalEventHandlers")]
    [NoInterfaceObject]
    public interface IGlobalEventHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        [ES("onabort")]
        event EventHandler Abort;

        /// <summary>
        /// 
        /// </summary>
        [ES("onblur")]
        event EventHandler Blur;

        /// <summary>
        /// 
        /// </summary>
        [ES("oncancel")]
        event EventHandler Cancel;

        /// <summary>
        /// 
        /// </summary>
        [ES("oncanplay")]
        event EventHandler CanPlay;

        /// <summary>
        /// 
        /// </summary>
        [ES("onchange")]
        event EventHandler Change;

        /// <summary>
        /// 
        /// </summary>
        [ES("onclick")]
        event EventHandler Click;

        /// <summary>
        /// 
        /// </summary>
        [ES("onclose")]
        event EventHandler Close;

        /// <summary>
        /// 
        /// </summary>
        [ES("oncuechange")]
        event EventHandler CueChange;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondblclick")]
        event EventHandler DblClick;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondrag")]
        event EventHandler Drag;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondragend")]
        event EventHandler DragEnd;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondragenter")]
        event EventHandler DragEnter;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondragexit")]
        event EventHandler DragExit;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondragleave")]
        event EventHandler DragLeave;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondragover")]
        event EventHandler DragOver;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondragstart")]
        event EventHandler DragStart;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondrop")]
        event EventHandler Drop;

        /// <summary>
        /// 
        /// </summary>
        [ES("ondurationchange")]
        event EventHandler DurationChange;

        /// <summary>
        /// 
        /// </summary>
        [ES("onemptied")]
        event EventHandler Emptied;

        /// <summary>
        /// 
        /// </summary>
        [ES("onended")]
        event EventHandler Ended;

        /// <summary>
        /// 
        /// </summary>
        [ES("onerror")]
        event EventHandler Error;

        /// <summary>
        /// 
        /// </summary>
        [ES("onfocus")]
        event EventHandler Focus;

        /// <summary>
        /// 
        /// </summary>
        [ES("oninput")]
        event EventHandler Input;

        /// <summary>
        /// 
        /// </summary>
        [ES("oninvalid")]
        event EventHandler Invalid;

        /// <summary>
        /// 
        /// </summary>
        [ES("onkeydown")]
        event EventHandler Keydown;

        /// <summary>
        /// 
        /// </summary>
        [ES("onkeypress")]
        event EventHandler Keypress;

        /// <summary>
        /// 
        /// </summary>
        [ES("onkeyup")]
        event EventHandler Keyup;

        /// <summary>
        /// 
        /// </summary>
        [ES("onload")]
        event EventHandler Load;

        /// <summary>
        /// 
        /// </summary>
        [ES("onloadeddata")]
        event EventHandler LoadedData;

        /// <summary>
        /// 
        /// </summary>
        [ES("onloadedmetadata")]
        event EventHandler LoadedMetaData;

        /// <summary>
        /// 
        /// </summary>
        [ES("onloadstart")]
        event EventHandler LoadStart;

        /// <summary>
        /// 
        /// </summary>
        [ES("onmousedown")]
        event EventHandler MouseDown;

        /// <summary>
        /// 
        /// </summary>
        [LenientThis]
        [ES("onmouseenter")]
        event EventHandler MouseEnter;

        /// <summary>
        /// 
        /// </summary>
        [LenientThis]
        [ES("onmouseleave")]
        event EventHandler MouseLeave;

        /// <summary>
        /// 
        /// </summary>
        [ES("onmousemove")]
        event EventHandler MouseMove;

        /// <summary>
        /// 
        /// </summary>
        [ES("onmouseout")]
        event EventHandler MouseOut;

        /// <summary>
        /// 
        /// </summary>
        [ES("onmouseover")]
        event EventHandler MouseOver;

        /// <summary>
        /// 
        /// </summary>
        [ES("onmouseup")]
        event EventHandler MouseUp;

        /// <summary>
        /// 
        /// </summary>
        [ES("onwheel")]
        event EventHandler Wheel;

        /// <summary>
        /// 
        /// </summary>
        [ES("onpause")]
        event EventHandler Pause;

        /// <summary>
        /// 
        /// </summary>
        [ES("onplay")]
        event EventHandler Play;

        /// <summary>
        /// 
        /// </summary>
        [ES("onplaying")]
        event EventHandler Playing;

        /// <summary>
        /// 
        /// </summary>
        [ES("onprogress")]
        event EventHandler Progress;

        /// <summary>
        /// 
        /// </summary>
        [ES("onratechange")]
        event EventHandler RateChange;

        /// <summary>
        /// 
        /// </summary>
        [ES("onreset")]
        event EventHandler Reset;

        /// <summary>
        /// 
        /// </summary>
        [ES("onresize")]
        event EventHandler Resize;

        /// <summary>
        /// 
        /// </summary>
        [ES("onscroll")]
        event EventHandler Scroll;

        /// <summary>
        /// 
        /// </summary>
        [ES("onseeked")]
        event EventHandler Seeked;

        /// <summary>
        /// 
        /// </summary>
        [ES("onseeking")]
        event EventHandler Seeking;

        /// <summary>
        /// 
        /// </summary>
        [ES("onselect")]
        event EventHandler Select;

        /// <summary>
        /// 
        /// </summary>
        [ES("onshow")]
        event EventHandler Show;

        /// <summary>
        /// 
        /// </summary>
        [ES("onstalled")]
        event EventHandler Stalled;

        /// <summary>
        /// 
        /// </summary>
        [ES("onsubmit")]
        event EventHandler Submit;

        /// <summary>
        /// 
        /// </summary>
        [ES("onsuspend")]
        event EventHandler Suspend;

        /// <summary>
        /// 
        /// </summary>
        [ES("ontimeupdate")]
        event EventHandler TimeUpdate;

        /// <summary>
        /// 
        /// </summary>
        [ES("ontoggle")]
        event EventHandler Toggle;

        /// <summary>
        /// 
        /// </summary>
        [ES("onvolumechange")]
        event EventHandler VolumeChange;

        /// <summary>
        /// 
        /// </summary>
        [ES("onwaiting")]
        event EventHandler Waiting;
    }
}
