using System;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public class HarbingerStateExecuterFactory : MonoBehaviour
    {
        public BossStateExecuter GetBossStateExecuter(HarbingerOfDeathState harbingerOfDeathState)
        {
            switch (harbingerOfDeathState)
            {
                case HarbingerOfDeathState.Movement:
                    return GetComponentInChildren<BossHarbingerMovementExecuter>();
                case HarbingerOfDeathState.Idle:
                    return GetComponentInChildren<HarbingerIdleExecuter>();
                case HarbingerOfDeathState.Attack:
                    return GetComponentInChildren<BossHarbingerAttackExecuter>();
                case HarbingerOfDeathState.Slash:
                    return GetComponentInChildren<HarbingerSlashExecuter>();
                case HarbingerOfDeathState.Heavy:
                    return GetComponentInChildren<HarbingerHeavyExecuter>();
                case HarbingerOfDeathState.Beam:
                    return GetComponentInChildren<HarbingerBeamExecuter>();
                case HarbingerOfDeathState.MultiBeam:
                    return GetComponentInChildren<HarbingerMultiBeamExecuter>();
                case HarbingerOfDeathState.Exhausted:
                    return GetComponentInChildren<HarbingerExhaustedExecuter>();
                case HarbingerOfDeathState.Enraged:
                    return GetComponentInChildren<HarbingerEnragedExecuter>();
                default:
                    throw new ArgumentOutOfRangeException("harbingerOfDeathState", harbingerOfDeathState, null);
            }

            return null;
        }
    }
}