﻿using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class BossAttackChoserBase : Trigger, BossStateExecuter
    {
        public bool PlayerInRange
        {
            get
            {
                return _isPlayerInRange;
            }
        }

        protected PossibleAttacks _possibleAttacks;

        private bool _isPlayerInRange;

        protected override void Start()
        {
            base.Start();
            _possibleAttacks = new PossibleAttacks();
            Tags.Add(Tag.PlayerCollision);
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _isPlayerInRange = true;
        }

        public override void OnExitWithTag()
        {
            base.OnExitWithTag();
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