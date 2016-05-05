using System;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerBeamExecuter : BossAttackBase
    {
        private float StartDelay = 1.5f;
        private BossBeam _bossBeam;

        protected override void Start()
        {
            base.Start();
            _bossBeam = transform.root.FindComponentInChildWithName<BossBeam>("Beam");
            _possiblePauseStates.Add(HarbingerOfDeathState.Enraged);
            _baseDamageXmlId = 2;
        }

        protected override void Attack()
        {
            StartAnimation();
            _bossBeam.StartAttack(_baseDamage, StartDelay, SwitchState);
        }
    }
}