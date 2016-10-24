using Assets.Scripts.Pathfinding;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class DefaultEnemyMovement : MonoBehaviour, Moveable
    {
        public UnityNavMeshAgentConfig NavMeshAgentConfig;

        private Pathfinding.NavMeshAgent _navMeshAgent;
        private Transform _playerTransform;

        private void Start()
        {
            _navMeshAgent = GetComponentInParent<Pathfinding.NavMeshAgent>();
            _navMeshAgent.Config.CopyValues(NavMeshAgentConfig);
            _playerTransform = GameObject.FindGameObjectWithTag(Tag.PlayerCollision).transform;
        }

        public void Resume()
        {
            _navMeshAgent.Resume();
            _navMeshAgent.Config = NavMeshAgentConfig;
            _navMeshAgent.MoveTo(_playerTransform.position);
        }

        public void Stop()
        {
            _navMeshAgent.Stop();
        }
    }
}