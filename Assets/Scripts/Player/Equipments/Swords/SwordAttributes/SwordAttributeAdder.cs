using System;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Player.Swords.Curses;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordAttributeAdder : AttributeAdder
    {
        private AttributeManager _attributeManager;

        public SwordAttributeAdder(AttributeManager attributeManager)
        {
            _attributeManager = attributeManager;
        }

        public MonoBehaviour AddAttribute(Enum swordAttribute)
        {
            switch ((SwordAttribute)swordAttribute)
            {
                case SwordAttribute.Broken:
                    return _attributeManager.AddNewAttribute<BrokenSwordCurse>(EquipmentAttributeType.Curse);
                case SwordAttribute.Enchant:
                    return _attributeManager.AddNewAttribute<EnchantedSwordBlessing>(EquipmentAttributeType.Blessing);
                case SwordAttribute.Heavy:
                    return _attributeManager.AddNewAttribute<HeavySwordCurse>(EquipmentAttributeType.Curse);
                case SwordAttribute.LifeDrain:
                    return _attributeManager.AddNewAttribute<LifeDrainSwordBlessing>(EquipmentAttributeType.Blessing);
                case SwordAttribute.Rusty:
                    return _attributeManager.AddNewAttribute<RustySwordCurse>(EquipmentAttributeType.Curse);
                case SwordAttribute.Vsteel:
                    return _attributeManager.AddNewAttribute<VsteelSwordBaseBlessing>(EquipmentAttributeType.Blessing);
                case SwordAttribute.Worn:
                    return _attributeManager.AddNewAttribute<WornSwordCurse>(EquipmentAttributeType.Curse);
                default:
                    return new EmptySwordComponent();
            }
        }
    }
}