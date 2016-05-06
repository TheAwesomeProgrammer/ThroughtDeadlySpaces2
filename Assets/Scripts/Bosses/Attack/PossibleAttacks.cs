using System;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class PossibleAttacks
    {
        protected List<Enum> _possibleMeleeAttacks;
        protected List<Enum> _possibleRangedAttacks;

        public PossibleAttacks()
        {
            _possibleMeleeAttacks = new List<Enum>();
            _possibleRangedAttacks = new List<Enum>();
        }

        public virtual Enum GetRandomMeleeAttackState()
        {
            return _possibleMeleeAttacks[Random.Range(0, _possibleMeleeAttacks.Count)];
        }

        public virtual Enum GetRandomRangedAttackState()
        {
            return _possibleRangedAttacks[Random.Range(0, _possibleRangedAttacks.Count)];
        }
    }
}