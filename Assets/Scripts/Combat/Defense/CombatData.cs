using System;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player.Equipments;
using UnityEngine;

namespace Assets.Scripts.Combat
{
    public class CombatData : ICloneable
    {
        public CombatType CombatType;

        private int _combatValue;

        public int CombatValue
        {
            get { return _combatValue; }
            set { _combatValue = Mathf.Clamp(value, 0, int.MaxValue); }
        }

        public CombatData(CombatType combatType, int combatValue)
        {
            CombatType = combatType;
            CombatValue = combatValue;
        }

        public virtual ModifierType GetModifierType()
        {
            if (CombatType == CombatType.BaseType)
            {
                return ModifierType.Base;
            }
            if (CombatType != CombatType.BaseType)
            {
                return ModifierType.AllButBase | ModifierType.All;
            }

            return ModifierType.None;
        }


        public override bool Equals(object obj)
        {
            CombatData otherDamageData = obj as CombatData;
            if (otherDamageData != null)
            {
                return (int)otherDamageData.CombatType == (int)CombatType;
            }
            return false;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    public override int GetHashCode()
        {
            return 1;
        }
    }
}