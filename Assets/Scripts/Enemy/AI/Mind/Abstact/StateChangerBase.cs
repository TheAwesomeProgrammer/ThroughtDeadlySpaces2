using Assets.Scripts.Enemy.AI;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class StateChangerBase : MonoBehaviour, StateChanger
    {
        protected GroupBehaviourManager _groupBehaviourManager;

        protected virtual void Start()
        {
            _groupBehaviourManager = GetComponentInParent<GroupBehaviourManager>();
        }

        protected virtual State GetState(StateType stateType)
        {
            return _groupBehaviourManager.GetState(stateType);
        }

        public abstract bool ShouldStateChange(State currentState, out State newState);
    }
}