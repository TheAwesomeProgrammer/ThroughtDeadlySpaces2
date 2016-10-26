using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Event
{
    public class EventManager : MonoBehaviour
    {
        private List<EventData> _subscribers;

        private void Awake()
        {
            _subscribers = new List<EventData>();
        }

        public void OnEvent(Enum eventType)
        {
            List<EventData> subscribersWithEventType = _subscribers.FindAll(item => item.EventType.Equals(eventType));
            subscribersWithEventType.ForEach(item => item.Callback());
        }

        public void Subscribe(Enum eventType, Action callback)
        {
            _subscribers.Add(new EventData(eventType, callback));
        }

        public void UnSubscribe(Enum eventType)
        {
            _subscribers.Remove(item => item.EventType.Equals(eventType));
        }

    }
}