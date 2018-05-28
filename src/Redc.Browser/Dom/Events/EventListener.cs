namespace Redc.Browser.Dom.Events
{
    /// <summary>
    /// Associates a callback with a specific event.
    /// </summary>
    internal struct EventListener
    {
        public EventHandler Callback;

        public string Type;

        public bool Capture;
    }
}
