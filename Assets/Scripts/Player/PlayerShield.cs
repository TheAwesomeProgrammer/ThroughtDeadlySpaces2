﻿using System.Collections.Generic;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Movement;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerShield : Trigger
    {
        private const int Cost = 1;
        private const int InFrontOfPlayerAngle = 90;

        private AnimatorTrigger _animatorTrigger;
        private DexterityFiller _dexterityFiller;
        private AbillityTiming _abillityTiming;

        private List<Attackable> _stoppedAttackers;

        protected override void Start()
        {
            base.Start();
            Tags.Add("EnemyAttack");
            Tags.Add("EnemyProjectile");
            _stoppedAttackers = new List<Attackable>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _dexterityFiller = GetComponentInParent<DexterityFiller>();
            _abillityTiming = GetComponent<AbillityTiming>();
            _abillityTiming.AbillityStart += OnAbillityStart;
            _abillityTiming.AbillityEnd += OnAbillityEnd;
            _animatorTrigger.AnimationStarting += OnShieldAnimationStarting;
        }

        void OnShieldAnimationStarting()
        {
            if (_abillityTiming.Active)
            {
                _animatorTrigger.Cancel();
            }
            _abillityTiming.UseAbillity();
        }

        private void OnAbillityStart()
        {
            if (_dexterityFiller.HasEnoughDexterity(Cost))
            {
                _dexterityFiller.Dexterity -= Cost;
            }
            else
            {
                _animatorTrigger.Cancel();
            }
        }

        private void OnAbillityEnd()
        {
            foreach (var stoppedAttacker in _stoppedAttackers)
            {
                stoppedAttacker.EnableAttack();
            }
            _animatorTrigger.End();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (_abillityTiming.Active && IsAttackerInFrontOfPlayer(_triggerCollider.transform.position))
            {
                Attackable attacker = _triggerCollider.GetComponent<Attackable>();
                AddAndStopAttackter(attacker);
            }
        }

        private void AddAndStopAttackter(Attackable attacker)
        {
            attacker.DeativateAttack();
            _stoppedAttackers.Add(attacker);
        }

        private bool IsAttackerInFrontOfPlayer(Vector3 attackerPosition)
        {
            float angleToAttacker = (attackerPosition - transform.position).GetAngleBasedOnDirection();
            float forwardAngle = transform.forward.GetAngleBasedOnDirection();
            return Mathf.Abs(angleToAttacker - forwardAngle) < InFrontOfPlayerAngle;
        }

        public override void OnExit()
        {
            base.OnExit();
            if (_abillityTiming.Active)
            {
                Attackable attacker = _triggerCollider.GetComponent<Attackable>();
                RemoveAndEnableAttacker(attacker);
            }
        }

        private void RemoveAndEnableAttacker(Attackable attacker)
        {
            attacker.EnableAttack();
            _stoppedAttackers.Remove(attacker);
        }

     
    }
}