using Assets.Scripts.Enemy.AI.Mind.Abstact;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class IdleState : AiState, StateEnter, StateExit
    {
        public override StateType StateType
        {
            get { return StateType.Idle; }
        }

        public void OnEnterState()
        {
            Debug.Log("Entering idle state");
        }

        public void OnExitState()
        {
            Debug.Log("Exiting idle state");
        }
    }
}