using Redc.Browser.Attributes;
using Redc.Browser.Dom.Events;

namespace Redc.Browser.Html.Interfaces
{
    [ES("WindowEventHandlers")]
    [NoInterfaceObject]
    public interface IWindowEventHandlers
    {       
        /// <summary>
        /// 
        /// </summary>
        [ES("onafterprint")]
        event EventHandler AfterPrint;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onbeforeprint")]
        event EventHandler BeforePrint;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onbeforeunload")]
        event EventHandler BeforeUnload;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onhashchange")]
        event EventHandler HashChange;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onlanguagechange")]
        event EventHandler LanguageChange;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onmessage")]
        event EventHandler Message;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onoffline")]
        event EventHandler Offline;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("ononline")]
        event EventHandler Online;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onpagehide")]
        event EventHandler PageHide;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onpageshow")]
        event EventHandler PageShow;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onrejectionhandled")]
        event EventHandler RejectionHandled;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onpopstate")]
        event EventHandler PopState;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onstorage")]
        event EventHandler Storage;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onunhandledrejection")]
        event EventHandler UnhandledRejection;
        
        /// <summary>
        /// 
        /// </summary>
        [ES("onunload")]
        event EventHandler Unload;
    }
}
