using System;
using System.Collections.Generic;
using System.Linq;
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

        public void OnEvent<TEventArgs>(Enum eventType, object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            List<EventData> subscribersWithEventType = _subscribers.FindAll(item => item.EventType.Equals(eventType));
            subscribersWithEventType.ForEach(item => item.Callback(sender, e));
        }

        public void Subscribe<TEventArgs>(Enum eventType, EventHandler<TEventArgs> callback) where TEventArgs : EventArgs
        {
            _subscribers.Add(new EventData<TEventArgs>(eventType, callback));
        }

        public void UnSubscribe(Enum eventType)
        {
            _subscribers.Remove(item => item.EventType.Equals(eventType));
        }
    }
}