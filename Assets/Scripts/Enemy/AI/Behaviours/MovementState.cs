using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Pathfinding;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class MovementState : AiState, StateEnter, StateExit
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