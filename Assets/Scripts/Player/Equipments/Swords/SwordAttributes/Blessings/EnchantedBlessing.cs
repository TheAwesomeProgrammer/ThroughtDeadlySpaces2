using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Shop;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class EnchantedBlessing : EquipmentAttribute, XmlAttributeLoadable, CombatModifier
    {
        public int ProcentChangeToEnchant = 10;
        public int EnchantDamage = 1;
        public const int BlessingId = 2;

        private bool _enchant;
        private DoubleEnchantChecker _doubleEnchantChecker;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlLocation.Blessing, BlessingId);
            }
        }

        public override void Init()
        {
            base.Init();
            ModifierType = ModifierType.All;
            GetComponent<SwordAttack>().AttackStarted += OnStartAttack;
            _doubleEnchantChecker = new DoubleEnchantChecker(this);
            _doubleEnchantChecker.Check();
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            ProcentChangeToEnchant = specs[0];
            EnchantDamage = specs[1];
        }

        void OnStartAttack()
        {
            _enchant = ShouldEnchantedHit();
        }

        CombatData EnchantDamageHit(CombatData damageData)
        {
            CombatData enchantedHit = damageData;

            damageData.CombatValue += EnchantDamage;

            return enchantedHit;
        }

        bool ShouldEnchantedHit()
        {
            return MathHelper.IsBetweenRandomProcentFrom0To100(ProcentChangeToEnchant);
        }

        public CombatData GetModifiedCombatData(CombatData damageData)
        {
            if (_enchant)
            {
                return EnchantDamageHit(damageData);
            }
            return damageData;
        }
    }
}