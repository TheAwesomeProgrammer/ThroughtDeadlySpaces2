using System;
using Assets.Scripts.Bosses.Bobo_the_mighty.Attacks;
using Assets.Scripts.Bosses.Bobo_the_mighty.Movement;
using Assets.Scripts.Bosses.Bobo_the_mighty.Pausers;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty
{
    public class BoboStateExecuterFactory : MonoBehaviour, BossFactoryable
    {
        public BossStateExecuter GetBossStateExecuter(Enum bossState)
        {
            switch ((BoboState)bossState)
            {
                case BoboState.Movement:
                    return GetComponentInChildren<BoboMovement>();
                case BoboState.Attack:
                    return GetComponentInChildren<BoboAttackChoserExecuter>();
                case BoboState.Bite:
                    return GetComponentInChildren<BoboBiteExecuter>();
                case BoboState.RapidFrenzy:
                    break;
                case BoboState.MinionSpawn:
                    break;
                case BoboState.Suck:
                    break;
                case BoboState.Jump:
                    return GetComponentInChildren<BoboJumpExecuter>(); 
                case BoboState.AcidSpit:
                    break;
                case BoboState.Idle:
                    return GetComponentInChildren<BoboIdlePauser>();
                default:
                    throw new ArgumentOutOfRangeException("bossState", bossState, null);
            }

            return null;
        }
    }
}