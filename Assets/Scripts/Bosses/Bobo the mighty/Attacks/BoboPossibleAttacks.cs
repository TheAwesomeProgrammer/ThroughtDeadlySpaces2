using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboPossibleAttacks : PossibleAttacks
    {
        private const int MinionSpawnThreeshold = 2000;
        private const int MaxBoboMinions = 10;

        public BoboPossibleAttacks()
        {
            _possibleRangedAttacks = new List<Enum>()
            {
                BoboState.Suck,
                //BoboState.Jump,
                //BoboState.AcidSpit,
                //BoboState.MinionSpawn
            };
            _possibleMeleeAttacks = new List<Enum>()
            {
                 BoboState.Bite,
                 //BoboState.RapidFrenzy
            };
        }

        public override Enum GetRandomRangedAttackState()
        {
            if (TooManyMinions())
            {
                return GetRandomRangedAttackNotMinionSpawn();
            }
           
            return base.GetRandomRangedAttackState();
        }

        private bool TooManyMinions()
        {
            return GameObject.FindGameObjectsWithTag("BoboMinion").Length > MaxBoboMinions;
        }

        private Enum GetRandomRangedAttackNotMinionSpawn()
        {
            Enum randomMeleeAttack = BoboState.MinionSpawn;
            int count = 0;
            while ((BoboState) randomMeleeAttack == BoboState.MinionSpawn)
            {
                randomMeleeAttack = base.GetRandomRangedAttackState();
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