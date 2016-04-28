using System;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat
{
    public abstract class CombatData
    {
        public CombatType CombatType;

        public CombatData(CombatType combatType)
        {
            CombatType = combatType;
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
    }
}