using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Armors.Blessing;
using Assets.Scripts.Player.Armors.Curses;
using Assets.Scripts.Player.Attributes;
using Assets.Scripts.Player.Attributes.Blessings.Mark;
using Assets.Scripts.Player.Curses;
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
        public EquipmentType EquipmentType;

        private EquipmentAttributeManager _equipmentAttributeManager;
        private int _id;
        

        public EquipmentAttributeAdder(EquipmentAttributeManager equipmentAttributeManager,EquipmentType equipmentType,  int id = 0)
        {
            _id = id;
            EquipmentType = equipmentType;
            _equipmentAttributeManager = equipmentAttributeManager;
            LoadAttributes(attributeData => attributeData.EquipmentAttributeType == EquipmentAttributeType.Blessing ||
            attributeData.EquipmentAttributeType == EquipmentAttributeType.Curse, Attributes);
        }

        public List<AttributeInfo> GetAttributeInfos(Predicate<AttributeInfo> predicate)
        {
            return Attributes.FindAll(predicate);
        }

        public override MonoBehaviour AddAttribute(Enum theEnum, int level = 1)
        {
            if (theEnum.GetType()  == typeof(SwordAttribute))
            {
                switch ((SwordAttribute)theEnum)
                {
                    case SwordAttribute.Rusty:
                        return AddAttribute(typeof(RustySwordCurse), level);
                    case SwordAttribute.Broken:
                        return AddAttribute(typeof(BrokenSwordCurse), level);
                    case SwordAttribute.Heavy:
                        return AddAttribute(typeof(HeavySwordCurse), level);
                    case SwordAttribute.Worn:
                        return AddAttribute(typeof(WornSwordCurse), level);
                    case SwordAttribute.Miss:
                        return AddAttribute(typeof(MissAttackSwordCurse), level);
                    case SwordAttribute.Vsteel:
                        return AddAttribute(typeof(VsteelSwordBaseBlessing), level);
                    case SwordAttribute.Enchant:
                        return AddAttribute(typeof(EnchantedBlessing), level);
                    case SwordAttribute.MarkDeath:
                        return AddAttribute(typeof(MarkDeathBlessing), level);
                    case SwordAttribute.MarkLife:
                        return AddAttribute(typeof(MarkLifeBlessing), level);
                    case SwordAttribute.MarkNature:
                        return AddAttribute(typeof(MarkNatureBlessing), level);
                    case SwordAttribute.MarkFire:
                        return AddAttribute(typeof(MarkFireBlessing), level);
                    case SwordAttribute.Lethal:
                        return AddAttribute(typeof(LethalBlessing), level);
                    case SwordAttribute.Fatiguing:
                        return AddAttribute(typeof(FatiguingCurse), level);
                    default:
                        throw new ArgumentOutOfRangeException("theEnum", theEnum, null);
                }
            }

            if (theEnum.GetType() == typeof(ArmorAttribute))
            {
                switch ((ArmorAttribute)theEnum)
                {
                    case ArmorAttribute.Broken:
                        return AddAttribute(typeof(ArmorBrokenCurse), level);
                    case ArmorAttribute.Rusty:
                        return AddAttribute(typeof(RustySwordCurse), level);
                    case ArmorAttribute.Enchant:
                        return AddAttribute(typeof(ArmorEnchantedBlessing), level);
                    case ArmorAttribute.Vsteel:
                        return AddAttribute(typeof(VstellArmorBlessing), level);
                    case ArmorAttribute.Holy:
                        return AddAttribute(typeof(HolyBlessing), level);
                    default:
                        throw new ArgumentOutOfRangeException("theEnum", theEnum, null);
                }
            }

            if (theEnum.GetType() == typeof(AttributeType))
            {
                switch ((AttributeType)theEnum)
                {
                    case AttributeType.Swift:
                        return AddAttribute(typeof(SwiftBlessing), level);
                    case AttributeType.Light:
                        return AddAttribute(typeof(LightBlessing), level);
                    case AttributeType.LifeDrain:
                        return AddAttribute(typeof(LifeDrainBlessing), level);
                    default:
                        throw new ArgumentOutOfRangeException("theEnum", theEnum, null);
                }
            }

            return null;
        }

        public override MonoBehaviour AddAttribute(Type equipmentAttribute, int level = 1)
        {
            MonoBehaviour attribute = null;

            Switch.Do(equipmentAttribute, Switch.Case<BrokenSwordCurse>(() => attribute = AddNLoadAttribute<BrokenSwordCurse>(level)),
                Switch.Case<EnchantedBlessing>(() => attribute = AddNLoadAttribute<EnchantedBlessing>(level)),
                Switch.Case<HeavySwordCurse>(() => attribute = AddNLoadAttribute<HeavySwordCurse>(level)),
                Switch.Case<LifeDrainBlessing>(() => attribute = AddNLoadAttribute<LifeDrainBlessing>(level)),
                Switch.Case<RustySwordCurse>(() => attribute = AddNLoadAttribute<RustySwordCurse>(level)),
                Switch.Case<VsteelSwordBaseBlessing>(() => attribute = AddNLoadAttribute<VsteelSwordBaseBlessing>(level)),
                Switch.Case<WornSwordCurse>(() => attribute = AddNLoadAttribute<WornSwordCurse>(level)),
                Switch.Case<MissAttackSwordCurse>(() => attribute = AddNLoadAttribute<MissAttackSwordCurse>(level)),
                Switch.Case<ArmorBrokenCurse>(() => attribute = AddNLoadAttribute<ArmorBrokenCurse>(level)),
                Switch.Case<ArmorRustyCurse>(() => attribute = AddNLoadAttribute<ArmorRustyCurse>(level)),
                Switch.Case<LifeDrainBlessing>(() => attribute = AddNLoadAttribute<LifeDrainBlessing>(level)),
                Switch.Case<ArmorEnchantedBlessing>(() => attribute = AddNLoadAttribute<ArmorEnchantedBlessing>(level)),
                Switch.Case<MarkDeathBlessing>(() => attribute = AddNLoadAttribute<MarkDeathBlessing>(level)),
                Switch.Case<MarkFireBlessing>(() => attribute = AddNLoadAttribute<MarkFireBlessing>(level)), 
                Switch.Case<MarkNatureBlessing>(() => attribute = AddNLoadAttribute<MarkNatureBlessing>(level)), 
                Switch.Case<MarkLifeBlessing>(() => attribute = AddNLoadAttribute<MarkLifeBlessing>(level)),
                Switch.Case<LightBlessing>(() => attribute = AddNLoadAttribute<LightBlessing>(level)),
                Switch.Case<SwiftBlessing>(() => attribute = AddNLoadAttribute<SwiftBlessing>(level)),
                Switch.Case<FatiguingCurse>(() => attribute = AddNLoadAttribute<FatiguingCurse>(level)),
                Switch.Case<MinusHpCurse>(() => attribute = AddNLoadAttribute<MinusHpCurse>(level)),
                Switch.Case<MinusMaxHpCurse>(() => attribute = AddNLoadAttribute<MinusMaxHpCurse>(level)),
                Switch.Case<LethalBlessing>(() => attribute = AddNLoadAttribute<LethalBlessing>(level)),
                Switch.Case<HolyBlessing>(() => attribute = AddNLoadAttribute<HolyBlessing>(level)),
                Switch.Case<VstellArmorBlessing>(() => attribute = AddNLoadAttribute<VstellArmorBlessing>(level)));

            return attribute;
        }

        private MonoBehaviour AddNLoadAttribute<T>(int level = 1) where T : MonoBehaviour
        {
            AttributeInfo attributeInfo = GetEquipmentAttributeInfo(typeof(T));
            attributeInfo.EquipmentType = EquipmentType;
            return _equipmentAttributeManager.AddNewAttribute<T>(_id, attributeInfo, level);
        }
    }
}