using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboPossibleAttacks : PossibleAttacks
    {
        public BoboPossibleAttacks()
        {
            _possibleRangedAttacks = new List<Enum>()
            {
                //BoboState.Suck,
                //BoboState.Jump,
                //BoboState.AcidSpit
            };
            _possibleMeleeAttacks = new List<Enum>()
            {
                 BoboState.Bite,
                 //BoboState.RapidFrenzy,
                 //BoboState.MinionSpawn
            };
        }

    }
}