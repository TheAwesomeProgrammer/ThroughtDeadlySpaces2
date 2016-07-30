using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class EnchantedBlessing : DamagesDataModifier, XmlAttributeLoadable
    {
        public int ProcentChangeToEnchant = 10;
        public int EnchantDamage = 1;
        public const int BlessingId = 2;

        private bool _enchant;
        private EquipmentAttributeLoader _equipmentAttributeLoader;
        private DoubleEnchantChecker _doubleEnchantChecker;

        public void Awake()
        {
            GetComponent<SwordAttack>().Attacking += OnAttacking;
            _doubleEnchantChecker = new DoubleEnchantChecker(this);
            _doubleEnchantChecker.Check();
        }

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(BlessingId, level, XmlName.Blessing);
            ProcentChangeToEnchant = specs[0];
            EnchantDamage = specs[1];
        }

        void OnAttacking()
        {
            _enchant = ShouldEnchantedHit();
        }

        void OnDestroy()
        {
            print("GG");
        }

        public override DamageData ModifydamageData(DamageData damageDatas)
        {
            if (_enchant)
            {
                return EnchantDamageHit(damageDatas);
            }
            return damageDatas;
        }

        DamageData EnchantDamageHit(DamageData damageData)
        {
            DamageData enchantedHit = damageData;

            damageData.Damage += EnchantDamage;

            return enchantedHit;
        }

        bool ShouldEnchantedHit()
        {
            return MathHelper.IsBetweenRandomProcentFrom0To100(ProcentChangeToEnchant);
        }
    }
}