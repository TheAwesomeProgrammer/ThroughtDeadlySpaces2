using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class HarbingerPauserBase : BossPauserBase
    {
        private BossSpecsLoader _bossSpecsLoader;

        protected override void Start()
        {
            base.Start();
            _movementState = HarbingerOfDeathState.Movement;
            _bossSpecsLoader = GetComponentInParent<BossSpecsLoader>();
            SetupWaitTimeSets();
        }

        protected override void SetupWaitTimeSets()
        {
            base.SetupWaitTimeSets();
            float[] pauseTimeSpecs = _bossSpecsLoader.BossSpecs.PauseTimeSpecs;
            _waitTimeSet = new Dictionary<Enum, float>()
            {
                {HarbingerOfDeathState.Slash, pauseTimeSpecs[0] },
                {HarbingerOfDeathState.Heavy, pauseTimeSpecs[1] },
                {HarbingerOfDeathState.Beam, pauseTimeSpecs[2] },
                {HarbingerOfDeathState.MultiBeam, pauseTimeSpecs[3] }
            };
        }
    }
}