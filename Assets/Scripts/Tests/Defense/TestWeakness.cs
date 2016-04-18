using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Tests.Helper;
using UnityEngine;

namespace Assets.Scripts.Tests.Defense
{
    public class TestWeakness : MonoBehaviour
    {
        public const int StartHealth = 3;

        private Weakness _weakness;
        private Life _life;

        void Start()
        {
            _weakness = GetComponent<Weakness>();
            _life = GetComponent<Life>();
            TestIfDamagesOneWeakness();
            Reset();
            TestIfBaseDamageWorks();
            Reset();
            TestThatItDosntDamageWhenHasNoWeakness();
            Reset();
            TestNoDamageWhenHasWeaknessButIsNotTheRightOne();
        }

        void Reset()
        {
            _weakness.Weaknesses.Clear();
        }

        void TestIfDamagesOneWeakness()
        {
            _life.SetHealth(StartHealth);
            CombatType weaknessType = CombatType.Type1;
            int damage = 2;

            _weakness.Weaknesses.Add(weaknessType);

            _weakness.DoDamage(new List<DamageData>() { new DamageData(weaknessType, damage) } );

            Assert.IsTrue(_life.Health == StartHealth - damage, "Testing if damages one weakness");
        }

        void TestIfBaseDamageWorks()
        {
            _life.SetHealth(StartHealth);
            int damage = 2;

            _weakness.DoDamage(new List<DamageData>() {new BaseDamageData(damage) });

            Assert.IsTrue(_life.Health == StartHealth - damage, "Testing if base damage works");
        }

        void TestThatItDosntDamageWhenHasNoWeakness()
        {
            _life.SetHealth(StartHealth);
            int damage = 2;

            _weakness.DoDamage(new List<DamageData>() {new DamageData(CombatType.Type1, damage)});

            Assert.IsTrue(_life.Health == StartHealth, "Testing that is dosn't damage when no weakness exists");
        }

        void TestNoDamageWhenHasWeaknessButIsNotTheRightOne()
        {
            _life.SetHealth(StartHealth);
            int damage = 2;

            _weakness.Weaknesses.Add(CombatType.Type2);

            _weakness.DoDamage(new List<DamageData>() { new DamageData(CombatType.Type1, damage) });

            Assert.IsTrue(_life.Health == StartHealth, "Testing no damage when has weakness but not the right one");
        }
    }
}