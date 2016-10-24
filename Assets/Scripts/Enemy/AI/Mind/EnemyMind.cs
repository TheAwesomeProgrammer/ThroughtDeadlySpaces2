using System;
using System.Collections.Generic;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMind : MonoBehaviour
    {
        public MonoBehaviour DefaultState;

        private List<StateData> _stateDatas;
        private StateData _currentStateData;

        public void Start()
        {
            _stateDatas = new List<StateData>();
            LoadStateDatas();
            ChangeTo(DefaultState.GetType());
        }

        private void LoadStateDatas()
        {
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                State state = child.GetComponent<State>();
                if (state != null)
                {
                    StateChanger[] stateChangers = child.GetComponents<StateChanger>();
                    _stateDatas.Add(new StateData(state, stateChangers));
                }
            }
        }

        public void Update()
        {
            Debug.Log("Current state : "+ _currentStateData.State);
            CheckForStateChange();
            _currentStateData.OnUpdateState();
        }

        private void CheckForStateChange()
        {
            Type newStateType;
            if (ShouldChangeState(_currentStateData, out newStateType))
            {
                ChangeTo(newStateType);
            }
        }

        private bool ShouldChangeState(StateData currentStateData, out Type newStateType)
        {
            foreach (var stateChanger in currentStateData.StateChangers)
            {
                if (stateChanger.ShouldStateChange(currentStateData.State, out newStateType))
                {
                    return true;
                }
            }

            newStateType = null;
            return false;
        }

        public void ChangeTo(Type newStateType)
        {
            if (_currentStateData != null)
            {
                _currentStateData.OnExitState(newStateType);
                print("Exiting old state " + _currentStateData.State);
            }

            _currentStateData = GetStateDataBy(newStateType);
            NullAsserter.Assert(_currentStateData, "New state");
            _currentStateData.OnEnterState();
            print("Entering new state "+ _currentStateData.State);
        }

        private StateData GetStateDataBy(Type stateType)
        {
            return _stateDatas.Find(item => item.State.GetType() == stateType);
        }
    }
}