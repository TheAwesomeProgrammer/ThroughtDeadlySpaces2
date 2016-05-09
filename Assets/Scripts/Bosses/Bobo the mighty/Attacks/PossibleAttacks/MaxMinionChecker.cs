using System;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class MaxMinionChecker
    {
        private const int MinionSpawnThreeshold = 2000;
        private const int MaxBoboMinions = 10;

        private BoboPossibleAttacks _boboPossibleAttacks;

        public MaxMinionChecker(BoboPossibleAttacks boboPossibleAttacks)
        {
            _boboPossibleAttacks = boboPossibleAttacks;
        }

        public bool TooManyMinions()
        {
            return GameObject.FindGameObjectsWithTag("BoboMinion").Length > MaxBoboMinions;
        }

        public Enum GetRandomRangedAttackNotMinionSpawn()
        {
            Enum randomMeleeAttack = BoboState.MinionSpawn;
            int count = 0;
            while ((BoboState) randomMeleeAttack == BoboState.MinionSpawn)
            {
                randomMeleeAttack = _boboPossibleAttacks.GetRandomRangedAttackState();
                count++;
                if (count > MinionSpawnThreeshold)
                {
                    randomMeleeAttack = BoboState.Jump;
                    break;
                }
            }
            return randomMeleeAttack;
        }
    }
}