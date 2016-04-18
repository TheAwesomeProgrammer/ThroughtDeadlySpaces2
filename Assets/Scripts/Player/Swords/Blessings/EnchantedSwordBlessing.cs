using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class EnchantedSwordBlessing : SwordDamagesDataModifier
    {
        public int ProcentChangeToEnchant = 10;
        public int EnchantDamage = 1;

        private bool _enchant;
        private XmlSearcher _xmlSearcher;

        void Awake()
        {
            GetComponent<SwordAttack>().Attacking += OnAttacking;
            LoadSpecs();
        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _xmlSearcher.GetSpecsWithId(2, "Blessings");
            ProcentChangeToEnchant = specs[0];
            EnchantDamage = specs[1];
        }

        void OnAttacking()
        {
            _enchant = false || ShouldEnchantedHit();
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