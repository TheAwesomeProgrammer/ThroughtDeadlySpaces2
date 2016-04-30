using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;

namespace Assets.Scripts.Player.Armors.ArmorModifier
{
    public abstract class ArmorReduceDefenseDataModifier : ArmorReduceModifier
    {
        public override CombatData GetModifiedCombatData(CombatData combatData)
        {
            base.GetModifiedCombatData(combatData);
            if (_defenseData.CombatType != CombatType.BaseType)
            {
                return ReduceDefenseData(_defenseData);
            }
            return _defenseData;
        }
    }
}