using System.Collections;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerMultiBeamExecuter : BossAttackBase
    {
        private float _attackSpeed;
        private const float StartDelay = 2.4f;
        private const float EndDelay = 0.75f;
        private const int TimesToAttack = 3;
        private BossBeam _bossBeam;
        private int _beamsFired;

        protected override void Start()
        {
            base.Start();
            _bossBeam = transform.root.FindComponentInChildWithName<BossBeam>("Beam");
            _bossAttack = transform.root.FindComponentInChildWithName<BossAttack>("Beam");
            _possiblePauseStates.Add(HarbingerOfDeathState.Exhausted);
            _baseDamageXmlId = 2;
            _attackSpeed = _bossSpecsLoader.BossSpecs.SpecialSpecs[0];
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
            float startDelay = 0;
            if (IsFirstBeam())
            {
                startDelay = StartDelay;
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
                Invoke("DoMultiBeam", _attackSpeed);
            }
            else
            {
                Timer.Start(EndDelay, SwitchState);
            }
        }
    }
}