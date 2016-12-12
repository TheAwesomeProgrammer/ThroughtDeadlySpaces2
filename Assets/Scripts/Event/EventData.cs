using System;
using Assets.Scripts.Extensions;

namespace Assets.Scripts.Event
{
    public abstract class EventData
    {
        public Enum EventType;
        public abstract void Callback(object sender, EventArgs e);
    }

    [Serializable]
    public class EventData<TEventArgs> : EventData where TEventArgs : EventArgs
    {
        public EventHandler<TEventArgs> EventHandler;

        public EventData(Enum eventType, EventHandler<TEventArgs> eventHandler)
        {
            EventType = eventType;
            EventHandler = eventHandler;
        }

        public override void Callback(object sender, EventArgs e)
        {
            if (e.GetType() == typeof (TEventArgs))
            {
                TEventArgs eventArgs = e as TEventArgs;
                EventHandler.InvokeIfNotNull(sender, eventArgs);
            }
        }
    }
}