using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordDamagesDataModifier : SwordComponent,SwordDamageModifier
    {
        public  DamageData GetModifiedDamageData(DamageData damageData)
        {
            if (damageData.CombatType != CombatType.BaseType)
            {
                return ModifydamageData(damageData);
            }
            return damageData;
        }

        public abstract DamageData ModifydamageData(DamageData damageData);
    }
}