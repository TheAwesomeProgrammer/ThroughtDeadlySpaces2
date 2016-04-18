﻿using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    public class BrokenSwordCurse : SwordBaseDamageModifier
    {
        public int BrokenSwordMinusProcentDamage = -40;

        private XmlSearcher _xmlSearcher;

        protected  override void Start()
        {
            base.Start();
        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Curse));
            BrokenSwordMinusProcentDamage = _xmlSearcher.GetSpecsWithId(0, "Curses")[0];
        }

        public override DamageData ModifydamageData(DamageData damageData)
        {
            return new BaseDamageData(MathHelper.GetValueMultipliedWithProcent(damageData.Damage, BrokenSwordMinusProcentDamage));
        }
    }
}