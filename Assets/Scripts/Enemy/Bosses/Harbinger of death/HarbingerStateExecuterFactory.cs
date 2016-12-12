using System;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public class HarbingerStateExecuterFactory : MonoBehaviour, BossFactoryable
    {
        public BossStateExecuter GetBossStateExecuter(Enum harbingerOfDeathState)
        {
            switch ((HarbingerOfDeathState)harbingerOfDeathState)
            {
                case HarbingerOfDeathState.Movement:
                    return GetComponentInChildren<BossMovementExecuter>();
                case HarbingerOfDeathState.Idle:
                    return GetComponentInChildren<HarbingerIdle>();
                case HarbingerOfDeathState.Attack:
                    return GetComponentInChildren<HarbingerAttackChoser>();
                case HarbingerOfDeathState.Slash:
                    return GetComponentInChildren<HarbingerSlashExecuter>();
                case HarbingerOfDeathState.Heavy:
                    return GetComponentInChildren<HarbingerHeavyExecuter>();
                case HarbingerOfDeathState.Beam:
                    return GetComponentInChildren<HarbingerBeamExecuter>();
                case HarbingerOfDeathState.MultiBeam:
                    return GetComponentInChildren<HarbingerMultiBeamExecuter>();
                case HarbingerOfDeathState.Exhausted:
                    return GetComponentInChildren<HarbingerExhausted>();
                case HarbingerOfDeathState.Enraged:
                    return GetComponentInChildren<HarbingerEnraged>();
                default:
                    throw new ArgumentOutOfRangeException("harbingerOfDeathState", harbingerOfDeathState, null);
            }
        }
    }
}