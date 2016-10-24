using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.Attacks.Abstract;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks
{
    public class RandomAttackSet : MonoBehaviour, AttackSet
    {
        private List<Attackable> _attacks;

        private void Awake()
        {
            FindAttacks();
        }

        private void FindAttacks()
        {
            _attacks = GetComponentsInChildren<Attackable>().ToList();
        }

        public Attackable GetAttack()
        {
            return _attacks.Random();
        }
    }
}