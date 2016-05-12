using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboPossibleAttacks : PossibleAttacks
    {
        private readonly MaxMinionChecker _maxMinionChecker;

        public BoboPossibleAttacks()
        {
            _possibleRangedAttacks = new List<Enum>()
            {
                //BoboState.Suck,
                BoboState.Jump,
                //BoboState.MinionSpawn
            };
            _possibleMeleeAttacks = new List<Enum>()
            {
                 BoboState.Bite,
                 BoboState.RapidFrenzy
            };
            _maxMinionChecker = new MaxMinionChecker(this);
        }

        public override Enum GetRandomRangedAttackState()
        {
            if (_maxMinionChecker.TooManyMinions())
            {
                return _maxMinionChecker.GetRandomRangedAttackNotMinionSpawn();
            }

            return base.GetRandomRangedAttackState();
        }
    }
}