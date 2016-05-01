using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class EnchantedBlessing : DamagesDataModifier
    {
        public int ProcentChangeToEnchant = 10;
        public int EnchantDamage = 1;
        public const int BlessingId = 2;

        private bool _enchant;
        private XmlSearcher _xmlSearcher;
        private DoubleEnchantChecker _doubleEnchantChecker;

        void Awake()
        {
            GetComponent<SwordAttack>().Attacking += OnAttacking;
            LoadSpecs();
            _doubleEnchantChecker = new DoubleEnchantChecker(this);
            _doubleEnchantChecker.Check();
        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _xmlSearcher.GetSpecsInChildrenWithId(BlessingId, "Blessings");
            ProcentChangeToEnchant = specs[0];
            EnchantDamage = specs[1];
        }

        void OnAttacking()
        {
            _enchant = ShouldEnchantedHit();
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