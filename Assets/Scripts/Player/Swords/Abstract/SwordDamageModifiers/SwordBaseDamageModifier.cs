using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordBaseDamageModifier : SwordDamageModifier
    {
        public override CombatData GetModifiedCombatData(CombatData combatData)
        {
            base.GetModifiedCombatData(combatData);
            if (_damageData.CombatType == CombatType.BaseType)
            {
                return ModifydamageData(_damageData);
            }
            return _damageData;
        }

        public abstract override DamageData ModifydamageData(DamageData damageData);

    }
}