using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
 

    public class PossibleAttacks
    {
        private HarbingerOfDeathState[] PossibleMeleeAttacks;
        private HarbingerOfDeathState[] PossibleRangedAttacks;

        public PossibleAttacks()
        {
            PossibleRangedAttacks = new[]
            {
                HarbingerOfDeathState.MultiBeam, 
                HarbingerOfDeathState.Beam
            };
            PossibleMeleeAttacks = new[]
            {
                HarbingerOfDeathState.Slash,
                HarbingerOfDeathState.Heavy
            };
        }

        public HarbingerOfDeathState GetRandomMeleeAttackState()
        {
            return PossibleMeleeAttacks[Random.Range(0, PossibleMeleeAttacks.Length)];
        }

        public HarbingerOfDeathState GetRandomRangedAttackState()
        {
            return PossibleRangedAttacks[Random.Range(0, PossibleRangedAttacks.Length)];
        }
    }
}