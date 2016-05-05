using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordAttack : SwordAttacker
    {
        protected override void Start()
        {
            base.Start();
            SetupDamageDatas();
        }

        void SetupDamageDatas()
        {
            _damageDatas.Add(new BaseDamageData(_sword.Specs.BaseDamage));
            _damageDatas.Add(new DamageData(CombatType.Type1, _sword.Specs.CombatType1Damage));
            _damageDatas.Add(new DamageData(CombatType.Type2, _sword.Specs.CombatType2Damage));
            _damageDatas.Add(new DamageData(CombatType.Type3, _sword.Specs.CombatType3Damage));
            _damageDatas.Add(new DamageData(CombatType.Type4, _sword.Specs.CombatType4Damage));
        }

        public void AddStrength(int strength)
        {
            _damageDatas.Find(damageData => damageData.CombatType == CombatType.BaseType).Damage += strength;
        }
    }
}