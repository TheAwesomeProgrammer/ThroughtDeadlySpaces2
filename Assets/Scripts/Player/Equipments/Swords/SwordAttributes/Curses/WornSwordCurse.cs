using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
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