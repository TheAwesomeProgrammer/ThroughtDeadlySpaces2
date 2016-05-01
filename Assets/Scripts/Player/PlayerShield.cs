using System.Collections.Generic;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Movement;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerShield : Trigger
    {
        private const int Cost = 1;

        private AnimatorTrigger _animatorTrigger;
        private DexterityFiller _dexterityFiller;
        private AbillityTiming _abillityTiming;

        private List<Attacker> _stoppedAttackers;

        protected override void Start()
        {
            base.Start();
            Tags.Add("EnemyAttack");
            _stoppedAttackers = new List<Attacker>();
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
                stoppedAttacker.StartAttack();
            }
            _animatorTrigger.End();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (_abillityTiming.Active)
            {
                Attacker attacker = _triggerCollider.GetComponent<Attacker>();
                AddAndStopAttackter(attacker);
            }
        }

        private void AddAndStopAttackter(Attacker attacker)
        {
            attacker.StopAttack();
            _stoppedAttackers.Add(attacker);
        }
    }
}