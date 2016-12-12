using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class HarbingerPauserBase : BossPauserBase
    {
        private EnemySpecsLoader EnemySpecsLoader;

        protected override void Start()
        {
            base.Start();
            _movementState = HarbingerOfDeathState.Movement;
            EnemySpecsLoader = GetComponentInParent<EnemySpecsLoader>();
            SetupWaitTimeSets();
        }

        protected override void SetupWaitTimeSets()
        {
            base.SetupWaitTimeSets();
            float[] pauseTimeSpecs = EnemySpecsLoader.EnemySpecs.PauseTimeSpecs;
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