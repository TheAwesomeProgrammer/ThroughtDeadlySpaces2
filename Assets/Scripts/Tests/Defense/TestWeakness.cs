using System.Collections.Generic;
using Assets.Scripts.Combat;
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
            CombatType weaknessType = CombatType.Fire;
            int damage = 2;

            _weakness.Weaknesses.Add(weaknessType);

            _weakness.DoDamage(new List<CombatData>() { new CombatData(weaknessType, damage) } );

            IntegrationAssert.IsTrue(_life.Health == StartHealth - damage, "Testing if damages one weakness");
        }

        void TestIfBaseDamageWorks()
        {
            _life.SetHealth(StartHealth);
            int damage = 2;

            _weakness.DoDamage(new List<CombatData>() {new CombatData(CombatType.BaseType, damage) });

            IntegrationAssert.IsTrue(_life.Health == StartHealth - damage, "Testing if base damage works");
        }

        void TestThatItDosntDamageWhenHasNoWeakness()
        {
            _life.SetHealth(StartHealth);
            int damage = 2;

            _weakness.DoDamage(new List<CombatData>() {new CombatData(CombatType.Fire, damage)});

            IntegrationAssert.IsTrue(_life.Health == StartHealth, "Testing that is dosn't damage when no weakness exists");
        }

        void TestNoDamageWhenHasWeaknessButIsNotTheRightOne()
        {
            _life.SetHealth(StartHealth);
            int damage = 2;

            _weakness.Weaknesses.Add(CombatType.Nature);

            _weakness.DoDamage(new List<CombatData>() { new CombatData(CombatType.Fire, damage) });

            IntegrationAssert.IsTrue(_life.Health == StartHealth, "Testing no damage when has weakness but not the right one");
        }
    }
}