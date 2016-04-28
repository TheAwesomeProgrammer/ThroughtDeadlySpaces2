using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Curses;
using Assets.Scripts.Tests.Helper;
using UnityEngine;

namespace Assets.Scripts.Tests.Player.Swords
{
    public class TestSwordAttack : MonoBehaviour
    {
        public GameObject Enemy;

        private SwordAttack _swordAttack;
        private const int StartHealth = 3;
        private Life _enemyLife;
        private Life _life;
        private Weakness _enemyWeakness;
        private AttributeManager _swordAttributeManager;

        void Start()
        {
            _swordAttack = GetComponent<SwordAttack>();
            _enemyLife = Enemy.GetComponent<Life>();
            _enemyWeakness = Enemy.GetComponent<Weakness>();
            _swordAttributeManager = GetComponent<AttributeManager>();
            _life = GetComponent<Life>();
            Invoke("DelayedStart", 0.5f);
        }

        void DelayedStart()
        {
            Reset();
            TestBaseDamageGoingThrough();
            Reset();
            TestIfDamageDataWithCombatType1GoesThroughWhenEnemyHasSameWeakness();
            Reset();
            TestIfDamageWithCombatType1DosntDoDamageWhenEnemyHasDifferentWeakness();
            Reset();
            TestIfStrengthDamageGoesThorugh();
            Reset();
            TestIfDamageIsReducedWhenHasBrokenSwordCurse();
            Reset();
            TestIfDamageIsReducedWhenHasRustySwordCurse();
            Reset();
            TestIfStrengthDamageIsSetToZeroWhenHasWornSwordCurse();
            Reset();
            TestIfVSteelBlessingIncreasesCriticalHitDamageByCriticalHitProcent();
            Reset();
            TestIfEnchantedSwordBlessingEnchantsDamageData();
            Reset();
            TestIfLifeDrainBlessingDrainsLifeOnHit();
        }
    
        void Reset()
        {
            _swordAttack.ClearDamageDatas();
            _enemyWeakness.Weaknesses.Clear();
            _swordAttributeManager.RemoveComponents<SwordBaseDamageModifier>();
            _swordAttributeManager.RemoveComponents<SwordStrengthDamageModifier>();
            _swordAttributeManager.RemoveComponents<SwordDamagesDataModifier>();
        }

        #region Sword attack only tests

        void TestBaseDamageGoingThrough()
        {
            int baseDamage = 2;
            _enemyLife.SetHealth(StartHealth);
            _swordAttack.AddDamageDatas(new List<DamageData>() {new BaseDamageData(baseDamage) });

            _swordAttack.Attack();

            Assert.IsEquals(_enemyLife.Health, StartHealth - baseDamage, "Test Base damage going through");
        }

        void TestIfDamageDataWithCombatType1GoesThroughWhenEnemyHasSameWeakness()
        {
            int damage = 2;
            _enemyLife.SetHealth(StartHealth);
            _swordAttack.AddDamageDatas(new List<DamageData>() {new DamageData(CombatType.Type1, damage)});
            _enemyWeakness.Weaknesses.Add(CombatType.Type1);

            _swordAttack.Attack();

            Assert.IsTrue(_enemyLife.Health == StartHealth - damage, "Test if damage with combat type 1, goes through, when enemy has same weakness");
        }

        void TestIfDamageWithCombatType1DosntDoDamageWhenEnemyHasDifferentWeakness()
        {
            int damage = 2;
            _enemyLife.SetHealth(StartHealth);
            _swordAttack.AddDamageDatas(new List<DamageData>() {new DamageData(CombatType.Type1, damage)});
            _enemyWeakness.Weaknesses.Add(CombatType.Type2);

            _swordAttack.Attack();

            Assert.IsTrue(_enemyLife.Health == StartHealth, "Test if Damage With Combat Type 1 Dosnt Do Damage When Enemy Has Different Weakness");
        }

        void TestIfStrengthDamageGoesThorugh()
        {
            int strengthDamage = 2;
            _enemyLife.SetHealth(StartHealth);
            _swordAttack.AddDamageDatas(new List<DamageData>() {new StrengthDamageData(strengthDamage)});

            _swordAttack.Attack();

            Assert.IsTrue(_enemyLife.Health == StartHealth - strengthDamage, "Test if strength damage goes through");
        }
        #endregion

        #region Sword curse attacks tests

        void TestIfDamageIsReducedWhenHasBrokenSwordCurse()
        {
            int damage = 10;
            _enemyLife.SetHealth(10);
            _swordAttack.AddDamageDatas(new List<DamageData>() {new BaseDamageData(damage)});
            BrokenSwordCurse brokenSwordCurse = _swordAttributeManager.AddNewComponent<BrokenSwordCurse>();

            Assert.IsEquals(MathHelper.GetValueMultipliedWithProcent(damage, brokenSwordCurse.BrokenSwordMinusProcentDamage),
                _swordAttack.Attack()[0].Damage, 
                "Testing if damage is reduced when has broken sword curse");
        }

        void TestIfDamageIsReducedWhenHasRustySwordCurse()
        {
            int damage = 10;
            _enemyLife.SetHealth(10);
            _swordAttack.AddDamageDatas(new List<DamageData>() { new BaseDamageData(damage) });
            RustySwordCurse rustySwordCurse = _swordAttributeManager.AddNewComponent<RustySwordCurse>();

            Assert.IsEquals(MathHelper.GetValueMultipliedWithProcent(damage, rustySwordCurse.MinusProcentDamage),
                _swordAttack.Attack()[0].Damage,
                "Testing if damage is reduced when has rusty sword curse");
        }

        void TestIfStrengthDamageIsSetToZeroWhenHasWornSwordCurse()
        {
            int damage = 10;
            _enemyLife.SetHealth(10);
            _swordAttack.AddDamageDatas(new List<DamageData>() { new StrengthDamageData(damage) });
            _swordAttributeManager.AddNewComponent<WornSwordCurse>();

            Assert.IsEquals(0,_swordAttack.Attack()[0].Damage,
                "Testing if strength is set to zero, when has worn sword curse");
        }


        #endregion

        #region blessing attacks tests

        void TestIfVSteelBlessingIncreasesCriticalHitDamageByCriticalHitProcent()
        {
            int damage = 10;
            _enemyLife.SetHealth(10);
            _swordAttack.AddDamageDatas(new List<DamageData>() { new BaseDamageData(damage) });
            VsteelSwordBaseBlessing vsteelSwordBaseBlessing = _swordAttributeManager.AddNewComponent<VsteelSwordBaseBlessing>();
            vsteelSwordBaseBlessing.ProcentChanceOfCriticalHit = 100;

            Assert.IsEquals(MathHelper.GetValueMultipliedWithProcent(damage, vsteelSwordBaseBlessing.CriticalHitDamageProcent),
                _swordAttack.Attack()[0].Damage,
                "Testing if vsteel blessing  increases damage  by critical hit procent");
        }

        void TestIfEnchantedSwordBlessingEnchantsDamageData()
        {
            int damage = 1;
            _enemyLife.SetHealth(10);
            _swordAttack.AddDamageDatas(new List<DamageData>() { new DamageData(CombatType.Type1, damage) });
            EnchantedSwordBlessing enchantedSwordBlessing = _swordAttributeManager.AddNewComponent<EnchantedSwordBlessing>();
            enchantedSwordBlessing.ProcentChangeToEnchant = 100;

            Assert.IsEquals(damage + enchantedSwordBlessing.EnchantDamage,
                _swordAttack.Attack()[0].Damage,
                "Testing if enchanted blessing increases damage  by one");
        }

        void TestIfLifeDrainBlessingDrainsLifeOnHit()
        {
            _life.SetHealth(StartHealth);

            LifeDrainSwordBlessing lifeDrainSwordBlessing = _swordAttributeManager.AddNewComponent<LifeDrainSwordBlessing>();
            lifeDrainSwordBlessing.ProcentChanceOfGainingLifeOnHit = 100;
            _life.MaxHealth = StartHealth + lifeDrainSwordBlessing.LifeOnHit;

            _swordAttack.Attack();

            Assert.IsEquals(StartHealth + lifeDrainSwordBlessing.LifeOnHit, _life.Health, 
                "Testing if life drain blessing drains life on hit");
        }

        #endregion
    }
}