using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Defense;

namespace Assets.Scripts.Player.Armors.ArmorModifier
{
    public abstract class ArmorBaseReduceModifier : ArmorReduceModifier
    {
        public override CombatData GetModifiedCombatData(CombatData combatData)
        {
            base.GetModifiedCombatData(combatData);

            if (_defenseData is BaseDefenseData)
            {
                ReduceDefenseData(_defenseData);
            }
            return _defenseData;
        }
    }
}