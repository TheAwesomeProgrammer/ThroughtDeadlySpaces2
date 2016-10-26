using System;

namespace Assets.Scripts.Event
{
    public class EventData
    {
        public Enum EventType;
        public Action Callback;

        public EventData(Enum eventType, Action callback)
        {
            EventType = eventType;
            Callback = callback;
        }
    }
}