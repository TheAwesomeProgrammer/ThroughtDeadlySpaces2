using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    public class WornSwordCurse : SwordStrengthDamageModifier
    {
        public override DamageData ModifydamageData(DamageData damageData)
        {
            DamageData modifiedDamageData = damageData;

            modifiedDamageData.Damage = 0;

            return modifiedDamageData;
        }
    }
}