using System.Collections.Generic;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class BossHarbingerAttackExecuter : Trigger,BossStateExecuter
    {
        private bool _isPlayerInRange;
        private PossibleAttacks _possibleAttacks;
        private BossSwordAttack _bossSwordAttack;

        protected override void Start()
        {
            base.Start();
            _possibleAttacks = new PossibleAttacks();
            Tags.Add("Player");
            _bossSwordAttack = transform.root.FindComponentInChildWithName<BossSwordAttack>("Sword");
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


        public void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            if (_isPlayerInRange)
            {
                _bossSwordAttack.OnAttackStarting();
                harbingerOfDeath.ChangeState(_possibleAttacks.GetRandomMeleeAttackState());
            }
            else
            {
                harbingerOfDeath.ChangeState(_possibleAttacks.GetRandomRangedAttackState());
            }
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {
            
        }
    }
}