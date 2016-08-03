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
        public void SetSword(Sword sword)
        {
            _sword = sword;
        }

        public void SetupDamageDatas()
        {
            _damageDatas.Add(new BaseDamageData(_sword.Specs.BaseDamage));
            _damageDatas.Add(new DamageData(CombatType.Fire, _sword.Specs.FireDamage));
            _damageDatas.Add(new DamageData(CombatType.Nature, _sword.Specs.NatureDamage));
            _damageDatas.Add(new DamageData(CombatType.Life, _sword.Specs.LifeDamage));
            _damageDatas.Add(new DamageData(CombatType.Death, _sword.Specs.DeathDamage));
        }

        public void AddStrength(int strength)
        {
            _damageDatas.Find(damageData => damageData.CombatType == CombatType.BaseType).Damage += strength;
        }
    }
}