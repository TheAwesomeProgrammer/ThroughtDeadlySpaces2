﻿using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordStrengthDamageModifier : SwordDamageModifier
    {
        public override CombatData GetModifiedCombatData(CombatData combatData)
        {
            base.GetModifiedCombatData(combatData);
            if (_damageData is StrengthDamageData)
            {
                return ModifydamageData(_damageData);
            }
            return _damageData;
        }
    }
}