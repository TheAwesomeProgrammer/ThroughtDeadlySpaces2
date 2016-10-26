using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Enemy.Attacks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Test
{
    public class AttackStateTest :  AiState, StateUpdateable
    {
        public override StateType StateType
        {
            get { return StateType.Attack; }
        }

        private RandomAttackSet _randomAttackSet;

        protected void Start()
        {
            _randomAttackSet = GetComponentInChildren<RandomAttackSet>();
        }

        public override void OnEnterState()
        {
            Debug.Log("Entered state");
            _randomAttackSet.GetAttack().DoAttack();
        }

        public void OnUpdateState()
        {
            Debug.Log("Updated state");
        }

        public override void OnExitState()
        {
            Debug.Log("Exited state");
        }
    }
}