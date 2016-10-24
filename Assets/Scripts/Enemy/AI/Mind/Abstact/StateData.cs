using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Enemy
{
    [Serializable]
    public class StateData
    {
        public State State;
        public List<StateChanger> StateChangers;

        public StateData(State state, IEnumerable<StateChanger> stateChangers)
        {
            State = state;
            StateChangers = stateChangers.ToList();
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
    }
}