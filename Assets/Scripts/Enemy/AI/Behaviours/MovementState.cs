using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Pathfinding;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class MovementState : AiState
    {
        public override StateType StateType
        {
            get { return StateType.Movement; }
        }

        private Moveable _enemyMovement;

        protected void Start()
        {
            _enemyMovement = GetComponent<Moveable>();
        }

        public override void OnEnterState()
        {
            _enemyMovement.Resume();
        }

        public override void OnExitState()
        {
            _enemyMovement.Stop();
        }
    }
}