using System;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.Test
{
    public class TestStateChanger : MonoBehaviour, StateChanger
    {
        private const int ChangeInterval = 3;

        private bool _canChange;

        private void Start()
        {
            Change();
        }

        public bool ShouldStateChange(State currentState, out State newState)
        {
            if (currentState.GetType() == typeof (AttackStateTest) && _canChange)
            {
                _canChange = false;
                newState = currentState;
                return true;
            }

            newState = null;
            return false;
        }

        private void Change()
        {
            _canChange = true;
            Timer.Start(gameObject, ChangeInterval, Change);
        }
        
    }
}