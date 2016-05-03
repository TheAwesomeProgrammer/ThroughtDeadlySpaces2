using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Pausers
{
    public abstract class BoboPauserBase : BossPauserBase
    {
        private BossSpecsLoader _bossSpecsLoader;

        protected override void Start()
        {
            base.Start();
            _movementState = BoboState.Movement;
            _bossSpecsLoader = GetComponentInParent<BossSpecsLoader>();
            SetupWaitTimeSets();
        }

        protected override void SetupWaitTimeSets()
        {
            base.SetupWaitTimeSets();
            float[] pauseTimeSpecs = _bossSpecsLoader.BossSpecs.PauseTimeSpecs;
            _waitTimeSet = new Dictionary<Enum, float>()
            {
                {BoboState.AcidSpit, pauseTimeSpecs[0] },
                {BoboState.Bite, pauseTimeSpecs[1] },
                {BoboState.Jump, pauseTimeSpecs[2] },
                {BoboState.MinionSpawn, pauseTimeSpecs[3] },
                {BoboState.RapidFrenzy, pauseTimeSpecs[4] },
                {BoboState.Suck, pauseTimeSpecs[5] }
            };
        }
    }
}