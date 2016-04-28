using System;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Defense
{
    public class DefenseData : CombatData,ICloneable
    {
        private int _defense;

        public int Defense
        {
            get { return _defense; }
            set { _defense = Mathf.Clamp(value, 0, int.MaxValue); }
        }

        public DefenseData(CombatType combatType, int defense) : base(combatType)
        {
            Defense = defense;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}