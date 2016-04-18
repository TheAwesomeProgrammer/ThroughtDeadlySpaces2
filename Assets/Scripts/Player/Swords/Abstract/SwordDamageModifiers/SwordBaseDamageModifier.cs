using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordBaseDamageModifier : SwordComponent, SwordDamageModifier
    {
        public DamageData GetModifiedDamageData(DamageData damageData)
        {
            if (damageData.CombatType == CombatType.BaseType)
            {
                return ModifydamageData(damageData);
            }
            return damageData;
        }

        public abstract DamageData ModifydamageData(DamageData damageData);

    }
}