using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class MovementChanger : MonoBehaviour, StateChanger
    {
        public MonoBehaviour IdleState;

        private Pathfinding.NavMeshAgent _navMeshAgent;
        private bool _navMeshAgentReachedTarget;
        private EnemyVision _enemyVision;

        private void Start()
        {
            _navMeshAgent = GetComponentInParent<Pathfinding.NavMeshAgent>();
            _enemyVision = GetComponentInParent<EnemyVision>();
            _navMeshAgent.ReachedTarget += OnNavMeshAgentReachedTarget;
        }

        private void OnNavMeshAgentReachedTarget(object sender, EventArgs e)
        {
            _navMeshAgentReachedTarget = true;
        }

        public bool ShouldStateChange(State currentState, out Type newStateType)
        {
            if (_navMeshAgentReachedTarget)
            {
                if (_enemyVision.CanSeePlayer())
                {
                    newStateType = currentState.GetType();
                }
                else
                {
                    newStateType = IdleState.GetType();
                }
                _navMeshAgentReachedTarget = false;
                return true;
            }

            newStateType = null;
            return false;
        }
    }
}