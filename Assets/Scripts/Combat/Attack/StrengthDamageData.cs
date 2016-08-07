using Assets.Scripts.Player.Equipments;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    public class StrengthDamageData : CombatData
    {
        public StrengthDamageData(int strengthDamage) : base(CombatType.BaseType, strengthDamage)
        {
        }

        public override ModifierType GetModifierType()
        {
            return ModifierType.Strength;
        }
    }
}