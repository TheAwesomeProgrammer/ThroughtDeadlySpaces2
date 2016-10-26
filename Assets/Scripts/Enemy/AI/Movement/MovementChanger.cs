using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class MovementChanger : MonoBehaviour, StateChanger
    {
        public AiState IdleState;

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

        public bool ShouldStateChange(State currentState, out State newState)
        {
            if (_navMeshAgentReachedTarget)
            {
                if (_enemyVision.CanSeePlayer())
                {
                    newState = currentState;
                }
                else
                {
                    newState = IdleState;
                }
                _navMeshAgentReachedTarget = false;
                return true;
            }

            newState = null;
            return false;
        }
    }
}