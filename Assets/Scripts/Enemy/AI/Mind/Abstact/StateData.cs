using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [Serializable]
    public class StateData
    {
        public State State;
        public List<StateChanger> StateChangers;

        private Transform _stateTransform;

        public StateData(State state, IEnumerable<StateChanger> stateChangers, Transform stateTransform = null)
        {
            State = state;
            StateChangers = stateChangers.ToList();
            _stateTransform = stateTransform;
        }

        public void OnEnterState()
        {
            State.OnEnterState();
        }

        public void OnUpdateState()
        {
            StateUpdateable stateUpdateable = State as StateUpdateable;
            if (stateUpdateable != null)
            {
                stateUpdateable.OnUpdateState();
            }
        }

        public void OnExitState(Type newState)
        {
            if (IsStateType(newState) && State.ExitOnReEntry || !IsStateType(newState))
            {
                State.OnExitState();
            }
        }

        public bool IsStateType(Type typeToCheck)
        {
            return State.GetType() == typeToCheck;
        }

        public override string ToString()
        {
            string stateChangersText = "";
            foreach (var stateChanger in StateChangers)
            {
                stateChangersText += stateChanger + " ";
            }

            return "State : " + State + Environment.NewLine +
                   "GameObject name " + _stateTransform.name + Environment.NewLine + 
                   "State changers : " + stateChangersText;
        }
    }
}