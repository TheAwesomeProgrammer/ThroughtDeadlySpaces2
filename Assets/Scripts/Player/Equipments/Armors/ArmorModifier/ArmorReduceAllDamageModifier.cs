﻿using Assets.Scripts.Combat;

namespace Assets.Scripts.Player.Armors.ArmorModifier
{
    public abstract class ArmorReduceAllDamageModifier : ArmorReduceModifier
    {
        public override CombatData GetModifiedCombatData(CombatData combatData)
        {
           return ReduceDefenseData(_defenseData);
        }
    }
}