using System;
using System.Collections.Generic;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerPossibleAttacks : PossibleAttacks
    {
        public HarbingerPossibleAttacks()
        {
            _possibleRangedAttacks = new List<Enum>()
            {
                HarbingerOfDeathState.MultiBeam,
                HarbingerOfDeathState.Beam
            };
            _possibleMeleeAttacks = new List<Enum>()
            {
                HarbingerOfDeathState.Slash,
                HarbingerOfDeathState.Heavy
            };
        }
    }
}