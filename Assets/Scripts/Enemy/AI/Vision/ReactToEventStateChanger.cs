using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Event;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Vision
{
    public class ReactToEventStateChanger : StateChangerBase
    {
        public StateType StateType;
        public AiEvent AiEvent;

        private EventManager _eventManager;
        private EventOnVisionStateChanger _eventOnVisionStateChanger;
        private bool _eventHappend;

        protected override void Start()
        {
            base.Start();
            _eventManager = GetComponentInParent<EventManager>();
            _eventOnVisionStateChanger = GetComponent<EventOnVisionStateChanger>();
            _eventManager.Subscribe<EventArgs>(AiEvent, OnEventRecived);
        }

        private void OnEventRecived(object sender, EventArgs e)
        {
            EventOnVisionStateChanger eventOnVisionStateChangerSender = sender as EventOnVisionStateChanger;
            if (eventOnVisionStateChangerSender != null && !eventOnVisionStateChangerSender.Equals(_eventOnVisionStateChanger))
            {
                _eventHappend = true;
            }
        }

        public override bool ShouldStateChange(State currentState, out State newState)
        {
            if (_eventHappend)
            {
                Debug.Log("Reacted to event "+ AiEvent);
                _eventHappend = false;
                newState =  GetState(StateType);
                return true;
            }

            newState = null;
            return false;
        }
    }
}