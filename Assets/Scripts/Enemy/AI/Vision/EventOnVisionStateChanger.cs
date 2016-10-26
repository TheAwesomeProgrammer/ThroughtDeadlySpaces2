using System;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Event;
using Assets.Scripts.Vision;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Vision
{
    public class EventOnVisionStateChanger : StateChangerBase
    {
        public AiEvent EventOnVision;

        private EnemyVision _enemyVision;
        private EventManager _eventManager;
        private StateTypeChooser _stateTypeChooser;

        protected override void Start()
        {
            base.Start();
            _stateTypeChooser = GetComponent<StateTypeChooser>();
            _eventManager = GetComponentInParent<EventManager>();
            _enemyVision = GetComponentInParent<EnemyVision>();
        }

        public override bool ShouldStateChange(State currentState, out State newState)
        {
            if (_enemyVision.CanSeePlayer())
            {
                newState = GetState(_stateTypeChooser.GetStateType());
                Debug.Log("Event on vision. New state type" + _stateTypeChooser.GetStateType());
                _eventManager.OnEvent(EventOnVision);
                return true;
            }

            newState = null;
            return false;
        }
    }
}