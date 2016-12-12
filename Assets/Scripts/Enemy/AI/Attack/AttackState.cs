using System;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Enemy.Attacks;
using Assets.Scripts.Enemy.Attacks.Abstract;
using Assets.Scripts.Extensions;

namespace Assets.Scripts.Enemy.AI.Attacks
{
    public class AttackEventArgs : EventArgs
    {
        public bool Active;

        public AttackEventArgs(bool active)
        {
            Active = active;
        }
    }

    public class AttackState : AiState, StateEnter, StateExit
    {
        public float AttackFrequency;

        public event EventHandler<AttackEventArgs> StartingAttack;

        private CombatActor<AttackStats> _currentAttack;
        private bool _active;

        public override StateType StateType
        {
            get { return StateType.Attack; }
        }

        public CombatActor<AttackStats> CurrentAttack
        {
            get { return _currentAttack; }
        }

        public void SetAttack(CombatActor<AttackStats> attack)
        {
            _currentAttack = attack;
        }

        public void OnEnterState()
        {
            _active = true;
            OnNextAttack();
        }

        private void OnNextAttack()
        {
            StartingAttack.InvokeIfNotNull(this, new AttackEventArgs(_active));
            if (_active)
            {
                Attack();
            }
        }

        private void Attack()
        {
            _currentAttack.DoAttack();
            Timer.Start(gameObject, AttackFrequency, OnNextAttack);
        }

        public void OnExitState()
        {
            _active = false;
        }
    }
}