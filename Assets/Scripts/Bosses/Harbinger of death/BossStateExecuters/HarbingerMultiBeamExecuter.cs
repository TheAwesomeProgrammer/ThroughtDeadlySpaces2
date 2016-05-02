using System.Collections;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerMultiBeamExecuter : HarbingerAttackBase
    {
        private float _attackSpeed;
        private const int StartDelay = 0;
        private const int TimesToAttack = 3;
        private BossBeam _bossBeam;
        private int _beamsFired;

        protected override void Start()
        {
            base.Start();
            _bossBeam = transform.root.FindComponentInChildWithName<BossBeam>("Beam");
            _bossSwordAttack = transform.root.FindComponentInChildWithName<BossSwordAttack>("Beam");
            _possiblePauseStates = new HarbingerOfDeathState[1]
            {
                HarbingerOfDeathState.Exhausted
            };
            _baseDamageXmlId = 2;
            _attackSpeed = _xmlSearcher.GetSpecsInChildrenWithIdFloat(BossId, "Bosses", "Beam")[0];
            _bossBeam.CallbackAction = HasDoneMultiBeam;
        }

        protected override void Attack()
        {
            base.Attack();
            DoMultiBeam();
        }

        public override void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            base.StartState(harbingerOfDeath);
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