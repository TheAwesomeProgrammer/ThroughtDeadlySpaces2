﻿using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    public class RustySwordCurse : BaseDamageModifier
    {
        public int MinusProcentDamage = -20;
        public int ProcentToBreakSword = 8;
        public const int CurseId = 2;

        private XmlSearcher _xmlSearcher;

        protected override void Start()
        {
            base.Start();
            GetComponent<SwordAttack>().AttackStarted += OnAttacking;
            LoadSpecs();
        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Curse));
            int[] specs = _xmlSearcher.GetSpecsInChildrenWithId(CurseId, "Curses");
            MinusProcentDamage = specs[0];
            ProcentToBreakSword = specs[1];
        }

        public override DamageData ModifydamageData(DamageData damageData)
        {
            return new BaseDamageData(MathHelper.GetValueMultipliedWithProcent(damageData.Damage, MinusProcentDamage));
        }

        void OnAttacking()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(ProcentToBreakSword) && !_swordAttributeManager.HasComponent<BrokenSwordCurse>())
            {
                _swordAttributeManager.AddNewComponent<BrokenSwordCurse>();
            }
        }

    }
}