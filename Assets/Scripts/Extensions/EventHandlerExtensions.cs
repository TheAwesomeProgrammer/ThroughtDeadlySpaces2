using System;

namespace Assets.Scripts.Extensions
{
    public static class EventHandlerExtensions
    {
        public static void InvokeIfNotNull<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(sender, e);
            }
        }
    }
}