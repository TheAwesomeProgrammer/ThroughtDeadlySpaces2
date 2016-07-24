using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Armors.Blessing;
using Assets.Scripts.Player.Armors.Curses;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Player.Swords.Curses;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public delegate MonoBehaviour AttributeAdding();

    public sealed class EquipmentAttributeAdder : AttributeAdder
    {
        private EquipmentAttributeManager _equipmentAttributeManager;

        public EquipmentAttributeAdder(EquipmentAttributeManager equipmentAttributeManager)
        {
            _equipmentAttributeManager = equipmentAttributeManager;
            LoadAttributes(attributeData => attributeData.EquipmentAttributeType == EquipmentAttributeType.Blessing ||
            attributeData.EquipmentAttributeType == EquipmentAttributeType.Curse, Attributes);
        }

        public List<AttributeInfo> GetAttributeInfos(Predicate<AttributeInfo> predicate)
        {
            return Attributes.FindAll(predicate);
        }

        public override MonoBehaviour AddAttribute(Enum theEnum)
        {
            if (Enum.IsDefined(typeof(SwordAttribute), theEnum))
            {
                switch ((SwordAttribute)theEnum)
                {
                    case SwordAttribute.Rusty:
                        return AddAttribute(typeof(RustySwordCurse));
                    case SwordAttribute.Broken:
                        return AddAttribute(typeof(BrokenSwordCurse));
                    case SwordAttribute.Heavy:
                        return AddAttribute(typeof(HeavySwordCurse));
                    case SwordAttribute.Worn:
                        return AddAttribute(typeof(WornSwordCurse));
                    case SwordAttribute.Miss:
                        return AddAttribute(typeof(MissAttackSwordCurse));
                    case SwordAttribute.Vsteel:
                        return AddAttribute(typeof(VsteelSwordBaseBlessing));
                    case SwordAttribute.LifeDrain:
                        return AddAttribute(typeof(LifeDrainSwordBlessing));
                    case SwordAttribute.Enchant:
                        return AddAttribute(typeof(EnchantedBlessing));
                    default:
                        throw new ArgumentOutOfRangeException("theEnum", theEnum, null);
                }
            }

            if (Enum.IsDefined(typeof(ArmorAttribute), theEnum))
            {
                switch ((ArmorAttribute)theEnum)
                {
                    case ArmorAttribute.Broken:
                        return AddAttribute(typeof(ArmorBrokenCurse));
                    case ArmorAttribute.Rusty:
                        return AddAttribute(typeof(RustySwordCurse));
                    case ArmorAttribute.LifeDrain:
                        return AddAttribute(typeof(LifeDrainSwordBlessing));
                    case ArmorAttribute.Enchant:
                        return AddAttribute(typeof(ArmorEnchantedBlessing));
                    case ArmorAttribute.Vsteel:
                        return AddAttribute(typeof(VstellArmorBlessing));
                    default:
                        throw new ArgumentOutOfRangeException("theEnum", theEnum, null);
                }
            }

            return new EmptySwordComponent();
        }

        public override MonoBehaviour AddAttribute(Type equipmentAttribute)
        {
            MonoBehaviour attribute = new EmptySwordComponent();

            TypeSwitch.Do(equipmentAttribute, 
                TypeSwitch.Case<BrokenSwordCurse>(() => attribute = AddNLoadAttribute<BrokenSwordCurse>()),
                TypeSwitch.Case<EnchantedBlessing>(() => attribute = AddNLoadAttribute<EnchantedBlessing>()),
                TypeSwitch.Case<HeavySwordCurse>(() => attribute = AddNLoadAttribute<HeavySwordCurse>()),
                TypeSwitch.Case<LifeDrainSwordBlessing>(() => attribute = AddNLoadAttribute<LifeDrainSwordBlessing>()),
                TypeSwitch.Case<RustySwordCurse>(() => attribute = AddNLoadAttribute<RustySwordCurse>()),
                TypeSwitch.Case<VsteelSwordBaseBlessing>(() => attribute = AddNLoadAttribute<VsteelSwordBaseBlessing>()),
                TypeSwitch.Case<WornSwordCurse>(() => attribute = AddNLoadAttribute<WornSwordCurse>()),
                TypeSwitch.Case<MissAttackSwordCurse>(() => attribute = AddNLoadAttribute<MissAttackSwordCurse>()),
                TypeSwitch.Case<ArmorBrokenCurse>(() => attribute = AddNLoadAttribute<ArmorBrokenCurse>()),
                TypeSwitch.Case<ArmorRustyCurse>(() => attribute = AddNLoadAttribute<ArmorRustyCurse>()),
                TypeSwitch.Case<LifeDrainSwordBlessing>(() => attribute = AddNLoadAttribute<LifeDrainSwordBlessing>()), 
                TypeSwitch.Case<ArmorEnchantedBlessing>(() => attribute = AddNLoadAttribute<ArmorEnchantedBlessing>()), 
                TypeSwitch.Case<VstellArmorBlessing>(() => attribute = AddNLoadAttribute<VstellArmorBlessing>()));

            return attribute;
        }

        private MonoBehaviour AddNLoadAttribute<T>() where T : MonoBehaviour
        {
            AttributeInfo attributeInfo = GetEquipmentAttributeInfo(typeof(T));
            return _equipmentAttributeManager.AddNewAttribute<T>(attributeInfo);
        }
    }
}