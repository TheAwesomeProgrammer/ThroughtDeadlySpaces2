using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [Serializable]
    public class StateData
    {
        public BehaviourType BehaviourType
        {
            get { return State.BehaviourType; }
        }

        public StateType StateType
        {
            get { return State.StateType; }
        }

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
            Null.Call(State as StateEnter, (stateEnter) => stateEnter.OnEnterState());
        }

        public void OnUpdateState()
        {
            Null.Call(State as StateUpdateable, (stateUpdateable) => stateUpdateable.OnUpdateState());
        }

        public void OnExitState(State state)
        {
            if (state.Equals(State) && State.ExitOnReEntry || !state.Equals(State))
            {
                Null.Call(State as StateExit, (stateExit) => stateExit.OnExitState());
            }
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