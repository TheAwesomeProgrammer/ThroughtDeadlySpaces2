using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player.Armors.ArmorModifier
{
    public abstract class ArmorReduceModifier : ArmorComponent,CombatModifier
    {
        protected DefenseData _defenseData;

        public virtual CombatData GetModifiedCombatData(CombatData combatData)
        {
            _defenseData = (DefenseData)combatData;
            return _defenseData;
        }

        public abstract DefenseData ReduceDefenseData(DefenseData defenseData);

    }
}