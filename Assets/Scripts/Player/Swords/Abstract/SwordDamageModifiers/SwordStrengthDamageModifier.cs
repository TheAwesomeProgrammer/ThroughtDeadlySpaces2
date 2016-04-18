using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordStrengthDamageModifier : SwordComponent, SwordDamageModifier
    {
        public DamageData GetModifiedDamageData(DamageData damageData)
        {
            if (damageData is StrengthDamageData)
            {
                return ModifydamageData(damageData);
            }
            return damageData;
        }
        public abstract DamageData ModifydamageData(DamageData damageData);
    }
}