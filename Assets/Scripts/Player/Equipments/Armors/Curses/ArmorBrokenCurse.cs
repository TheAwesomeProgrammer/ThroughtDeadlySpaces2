using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Armors.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Curse)]
    public class ArmorBrokenCurse : EquipmentAttribute, CombatModifier
    {
        public override AttributeXmlData AttributeXmlData
        {
            get { return null; }
        }

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.All;
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            damageData.CombatValue = 0;
            return damageData;
        }
    }
}