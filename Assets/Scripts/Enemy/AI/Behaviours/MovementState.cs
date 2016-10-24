using Assets.Scripts.Pathfinding;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class MovementState : MonoBehaviour, State
    {
        public bool ExitOnReEntry
        {
            get { return false; }
        }

        private Moveable _enemyMovement;

        private void Start()
        {
            _enemyMovement = GetComponent<Moveable>();
        }

        public void OnEnterState()
        {
            _enemyMovement.Resume();
        }

        public void OnExitState()
        {
            _enemyMovement.Stop();
        }
    }
}