using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Enemy.Attacks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Test
{
    public class AttackStateTest :  AiState, StateUpdateable, StateEnter, StateExit
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

        public void OnEnterState()
        {
            Debug.Log("Entered state");
            _randomAttackSet.GetCombat().DoAttack();
        }

        public void OnUpdateState()
        {
            Debug.Log("Updated state");
        }

        public void OnExitState()
        {
            Debug.Log("Exited state");
        }
    }
}