using System;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    [System.Serializable]
    public class DamageData : CombatData, ICloneable
    {
        private int _damage;

        public int Damage
        {
            get { return _damage; }
            set { _damage = Mathf.Clamp(value, 0, int.MaxValue); }
        }

        public DamageData(CombatType combatType, int damage) : base(combatType)
        {
            Damage = damage;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}