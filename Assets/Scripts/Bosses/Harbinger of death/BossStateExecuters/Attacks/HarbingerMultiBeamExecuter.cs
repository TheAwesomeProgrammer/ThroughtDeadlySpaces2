using System.Collections;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerMultiBeamExecuter : BossAttackBase
    {
        private float _attackSpeed;
        private const int StartDelay = 3;
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
            _bossBeam.CallbackAction = HasDoneMultiBeam;
        }

        protected override void Attack()
        {
            base.Attack();
            DoMultiBeam();
        }

        public override void StartState(BossStateMachine bossStateMachine)
        {
            base.StartState(bossStateMachine);
            _bossBeam.StartDelay = StartDelay;
        }

        void DoMultiBeam()
        {
            _bossBeam.StartAttack();
            _beamsFired++;
        }

        void HasDoneMultiBeam()
        {
            if (_beamsFired < TimesToAttack)
            {
                Invoke("DoMultiBeam", _attackSpeed);
            }
            else
            {
                SwitchState();
            }
        }
    }
}