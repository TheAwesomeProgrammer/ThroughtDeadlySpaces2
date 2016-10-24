using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMind : MonoBehaviour
    {
        public MonoBehaviour DefaultState;
        public List<MonoBehaviour> GlobalStateChangersScripts; 

        private List<StateData> _stateDatas;
        private StateData _currentStateData;
        private IEnumerable<StateChanger> _globalStateChangers;

        public void Start()
        {
            _stateDatas = new List<StateData>();
            _globalStateChangers = GlobalStateChangersScripts.Select(item => item.GetComponent<StateChanger>());
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
                    _stateDatas.Add(new StateData(state, stateChangers, child));
                }
            }
        }

        public void Update()
        {
            Debug.Log("Current state : "+ _currentStateData);
            CheckForGlobalStateChange();
            CheckForStateChange(_currentStateData);
            _currentStateData.OnUpdateState();
        }

        private void CheckForGlobalStateChange()
        {
            CheckForStateChange(new StateData(_currentStateData.State, _globalStateChangers));
        }

        private void CheckForStateChange(StateData stateData)
        {
            Type newStateType;
            if (ShouldChangeState(stateData, out newStateType))
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
                print("Exiting old state " + _currentStateData);
                _currentStateData.OnExitState(newStateType);
            }

            _currentStateData = GetStateDataBy(newStateType);
            NullAsserter.Assert(_currentStateData, "Current state data");
            print("Entering new state " + _currentStateData);
            _currentStateData.OnEnterState();
        }

        private StateData GetStateDataBy(Type stateType)
        {
            return _stateDatas.Find(item => item.State.GetType() == stateType);
        }
    }
}