using System;
using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class CombatModifierCaller
    {
        public CombatData GetModifiedData(EquipmentAttribute modifier, CombatData combatData)
        {
            ModifierType combatModifierType = combatData.GetModifierType();

            if ((modifier.ModifierType & combatModifierType) != 0)
            {
                CombatModifier combatModifier = modifier as CombatModifier;
                Null.OnNot(combatModifier, () => combatData = combatModifier.GetModifiedCombatData(combatData));
            }

            return combatData;

        }
    }
}