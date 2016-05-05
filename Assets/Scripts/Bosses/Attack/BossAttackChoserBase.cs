using System.Collections.Generic;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class BossAttackChoserBase : Trigger, BossStateExecuter
    {
        protected PossibleAttacks _possibleAttacks;

        private bool _isPlayerInRange;

        protected override void Start()
        {
            base.Start();
            _possibleAttacks = new PossibleAttacks();
            Tags.Add("Player");
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _isPlayerInRange = true;
        }

        public override void OnExit()
        {
            base.OnExit();
            _isPlayerInRange = false;
        }

        public void StartState(BossStateMachine bossStateMachine)
        {
            ChooseAttack(bossStateMachine);
        }

        protected virtual void ChooseAttack(BossStateMachine bossStateMachine)
        {
            if (_isPlayerInRange)
            {
                bossStateMachine.ChangeState(_possibleAttacks.GetRandomMeleeAttackState());
            }
            else
            {
                bossStateMachine.ChangeState(_possibleAttacks.GetRandomRangedAttackState());
            }
        }

        public void EndState(BossStateMachine bossStateMachine)
        {
            
        }
    }
}