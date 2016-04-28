using System;
using Assets.Scripts.Player.Armor.Blessing;
using Assets.Scripts.Player.Armor.Curses;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Armor
{
    public class ArmorAttributeAdder : AttributeAdder
    {
        private AttributeManager _ArmorAttributeManager;
        private AttributeManager _swordAttributeManager; 

        public ArmorAttributeAdder(AttributeManager armorAttributeManager, AttributeManager swordAttributeManager)
        {
            _ArmorAttributeManager = armorAttributeManager;
            _swordAttributeManager = swordAttributeManager;
        }

        public MonoBehaviour AddAttribute(Enum attribute)
        {
            switch ((ArmorAttribute)attribute)
            {
                case ArmorAttribute.Broken:
                    return _ArmorAttributeManager.AddNewAttribute<ArmorBrokenCurse>(EquipmentAttributeType.Curse);
                case ArmorAttribute.Rusty:
                    return _ArmorAttributeManager.AddNewAttribute<ArmorRustyCurse>(EquipmentAttributeType.Curse);
                case ArmorAttribute.LifeDrain:
                    return _swordAttributeManager.AddNewAttribute<LifeDrainSwordBlessing>(EquipmentAttributeType.Blessing);
                case ArmorAttribute.Enchant:
                    return _ArmorAttributeManager.AddNewAttribute<ArmorEnchantedBlessing>(EquipmentAttributeType.Blessing);
                case ArmorAttribute.Vsteel:
                    return _ArmorAttributeManager.AddNewAttribute<VstellArmorBlessing>(EquipmentAttributeType.Blessing);
                default:
                    throw new ArgumentOutOfRangeException("attribute", attribute, null);
            }
        }
    }
}