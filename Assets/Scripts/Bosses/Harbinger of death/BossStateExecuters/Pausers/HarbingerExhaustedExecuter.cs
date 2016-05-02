using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerExhaustedExecuter : HarbingerPauseExecuter
    {
        private LookAtTargetXz _lookAtTargetXz;

        protected override void Start()
        {
            base.Start();
            _lookAtTargetXz = GetComponentInParent<LookAtTargetXz>();
        }

        public override void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            base.StartState(harbingerOfDeath);
            _lookAtTargetXz.CanLook = false;
        }

        public override void EndState(HarbingerOfDeath harbingerOfDeath)
        {
            base.EndState(harbingerOfDeath);
            _lookAtTargetXz.CanLook = true;
        }
    }
}