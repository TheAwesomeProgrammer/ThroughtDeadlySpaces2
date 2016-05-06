using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerExhausted : HarbingerPauserBase
    {
        private LookAtTargetXz _lookAtTargetXz;

        protected override void Start()
        {
            base.Start();
            _lookAtTargetXz = GetComponentInParent<LookAtTargetXz>();
        }

        public override void StartState(BossStateMachine bossStateMachine)
        {
            base.StartState(bossStateMachine);
            _lookAtTargetXz.StopLooking();
        }

        public override void EndState(BossStateMachine bossStateMachine)
        {
            base.EndState(bossStateMachine);
            _lookAtTargetXz.StartLooking();
        }
    }
}