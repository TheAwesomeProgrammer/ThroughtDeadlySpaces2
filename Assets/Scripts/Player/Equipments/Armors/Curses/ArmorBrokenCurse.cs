using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Player.Armors.ArmorModifier;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Armors.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Curse)]
    public class ArmorBrokenCurse : ArmorReduceModifier
    {
        public override DefenseData ReduceDefenseData(DefenseData defenseData)
        {
            defenseData.Defense = 0;
            return defenseData;
        }
    }
}