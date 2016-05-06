using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.AcidSpit
{
    public class BoboAcidSpitExecuter : BossAttackBase
    {
        private LookAtTargetXz _lookAtTargetXz;

        protected override void Start()
        {
            base.Start();
            _lookAtTargetXz = transform.root.GetComponentInChildren<LookAtTargetXz>();
        }

        protected override void Attack()
        {
            base.Attack();
            _lookAtTargetXz.StopLooking();
        }
    }
}