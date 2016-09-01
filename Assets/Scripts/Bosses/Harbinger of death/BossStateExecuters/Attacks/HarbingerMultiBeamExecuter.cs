using System.Collections;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerMultiBeamExecuter : BossAttackBase
    {
        private float _betweenBeamDelay;
        private const float BaseStartDelay = 0.83f;
        private const float BaseEndDelay = 0.33f;
        private const float BaseBetweenBeamDelay = 1.0035f;
        private const int TimesToAttack = 3;
        private BossBeam _bossBeam;
        private int _beamsFired;
        private float _startDelay; 
        private float _endDelay;
        private float _calculatedAnimationDuration;

        public override string AnimationName
        {
            get { return "MultiLazorJoseph"; }
        }

        protected override void Start()
        {
            base.Start();
            _animator = _animatorTrigger.Animator;
            _bossBeam = transform.root.FindComponentInChildWithName<BossBeam>("Beam");
            _bossAttack = transform.root.FindComponentInChildWithName<BossAttack>("Beam");
            _possiblePauseStates.Add(HarbingerOfDeathState.Exhausted);
            _baseDamageXmlId = 2;
            _betweenBeamDelay = _bossSpecsLoader.BossSpecs.SpecialSpecs[0];
            CalculateDelays();
        }

        private void CalculateDelays()
        {
            float animationProcentIncrease = _betweenBeamDelay / BaseBetweenBeamDelay;
            _startDelay = BaseStartDelay * animationProcentIncrease;
            _endDelay = BaseEndDelay * animationProcentIncrease;
            _calculatedAnimationDuration = _startDelay + (TimesToAttack * _betweenBeamDelay) + _endDelay;
        }

        protected override void Attack()
        {
            StartAnimation();
            DoMultiBeam();
        }

        public override void StartState(BossStateMachine bossStateMachine)
        {
            _beamsFired = 0;
            base.StartState(bossStateMachine);
        }

        void DoMultiBeam()
        {
            _animator.SetFloat("AttackSpeed", _calculatedAnimationDuration);
            float startDelay = 0;
            if (IsFirstBeam())
            {
                startDelay = _startDelay;
            }

            _bossBeam.StartAttack(_baseDamage, startDelay, HasDoneMultiBeam);
            _beamsFired++;
        }

        private bool IsFirstBeam()
        {
            return _beamsFired == 0;
        }

        void HasDoneMultiBeam()
        {
            if (_beamsFired < TimesToAttack)
            {
                Invoke("DoMultiBeam", _betweenBeamDelay);
            }
            else
            {
                Timer.Start(gameObject, _endDelay, SwitchState);
            }
        }
    }
}