using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class DamagesDataModifier : DamageModifier
    {
        public override CombatData GetModifiedCombatData(CombatData combatData)
        {
            base.GetModifiedCombatData(combatData);
            if (_damageData.CombatType != CombatType.BaseType)
            {
                return ModifydamageData(_damageData);
            }
            return _damageData;
        }
    }
}