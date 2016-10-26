using Assets.Scripts.Enemy.AI.Mind.Abstact;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class IdleState : AiState
    {
        public override StateType StateType
        {
            get { return StateType.Idle; }
        }

        public override void OnEnterState()
        {
            Debug.Log("Entering idle state");
        }

        public override void OnExitState()
        {
            Debug.Log("Exiting idle state");
        }
    }
}