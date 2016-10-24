using Assets.Scripts.Enemy.Attacks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Test
{
    public class AttackStateTest :  MonoBehaviour, State, StateUpdateable
    {
        private RandomAttackSet _randomAttackSet;

        public bool ExitOnReEntry
        {
            get { return false; }
        }

        private void Start()
        {
            _randomAttackSet = GetComponentInChildren<RandomAttackSet>();
        }

        

        public void OnEnterState()
        {
            Debug.Log("Entered state");
            _randomAttackSet.GetAttack().DoAttack();
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