using System;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerBeamExecuter : BossAttackBase
    {
        private const float StartDelay = 0.5f;
        private BossBeam _bossBeam;

        protected override void Start()
        {
            base.Start();
            _bossBeam = transform.root.FindComponentInChildWithName<BossBeam>("Beam");
            _bossAttack = transform.root.FindComponentInChildWithName<BossAttack>("Beam");
            _possiblePauseStates.Add(HarbingerOfDeathState.Enraged);
            _baseDamageXmlId = 2;
        }

        public override void StartState(BossStateMachine bossStateMachine)
        {
            base.StartState(bossStateMachine);
            _bossBeam.StartDelay = StartDelay;
        }

        protected override void Attack()
        {
            base.Attack();
            _bossBeam.CallbackAction = SwitchState;
            _bossBeam.StartAttack();
        }
    }
}