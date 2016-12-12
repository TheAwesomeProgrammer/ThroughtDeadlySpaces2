using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMind : MonoBehaviour
    {
        public StateData CurrentStateData
        {
            get { return _currentStateData; }
        }

        public AiState DefaultState;
        public List<StateChangerBase> GlobalStateChangersScripts;

        private List<StateData> _stateDatas;
        private StateData _currentStateData;
        private IEnumerable<StateChanger> _globalStateChangers;

        public void Start()
        {
            _stateDatas = new List<StateData>();
            _globalStateChangers = GlobalStateChangersScripts.Select(item => item.GetComponent<StateChanger>());
            LoadStateDatas();
            ChangeTo(DefaultState);
        }

        private void LoadStateDatas()
        {
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                AiState state = child.GetComponent<AiState>();
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
            State newState;
            if (ShouldChangeState(stateData, out newState))
            {
                ChangeTo(newState);
            }
        }

        private bool ShouldChangeState(StateData currentStateData, out State newState)
        {
            foreach (var stateChanger in currentStateData.StateChangers)
            {
                if (stateChanger.ShouldStateChange(currentStateData.State, out newState))
                {
                    return true;
                }
            }

            newState = null;
            return false;
        }

        public void ChangeTo(State newState)
        {
            if (_currentStateData != null)
            {
                print("Exiting old state " + _currentStateData);
                _currentStateData.OnExitState(newState);
            }

            _currentStateData = GetStateDataBy(newState);
            NullAsserter.Assert(_currentStateData, "Current state data");
            print("Entering new state " + _currentStateData);
            _currentStateData.OnEnterState();
        }

        private StateData GetStateDataBy(State state)
        {
            return _stateDatas.Find(item => item.State == state);
        }
    }
}