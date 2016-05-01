using System.Collections;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerMultiBeamExecuter : HarbingerAttackBase
    {
        private float _attackSpeed;
        private const int TimesToAttack = 4;
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
        }

        protected override void Attack()
        {
            DoMultiBeam();
        }

        void DoMultiBeam()
        {
            base.Attack();
            _bossBeam.OnAttackStarted(HasDoneMultiBeam);
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