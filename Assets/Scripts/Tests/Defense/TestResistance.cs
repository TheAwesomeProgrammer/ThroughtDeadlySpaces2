using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Tests.Helper;
using UnityEngine;

public class TestResistance : MonoBehaviour
{
    public int StartHealth = 3;

    private Resistance _resistance;
    private Life _life;

    void Start()
    {
        _resistance = GetComponent<Resistance>();
        _life = GetComponent<Life>();
        TestIfDamageNDefenseMitegatesEachOther();
        Reset();
        TestIfDamageGetsThroughDefense();
        Reset();
        TestIfResistanceWithExtraDefenseStopsDamage();
        Reset();
        TestIfDifferentDamageTypeThanDefenseDoesDamage();
        Reset();
        TestIfDoesBaseDamage();
    }

    void Reset()
    {
        _resistance.DefenseDatas.Clear();
    }

    void TestIfDamageNDefenseMitegatesEachOther()
    {
        _life.SetHealth(StartHealth);
        int damage = 2;
        int defense = 2;

        SetupDamageNDefense(damage, defense, CombatType.Fire, CombatType.Fire);

        Assert.IsTrue(_life.Health == StartHealth, "Testing if damage n defense mitegaes each other");
    }

    void SetupDamageNDefense(int damage, int defense, CombatType defenseType, CombatType combatType)
    {
        _resistance.DefenseDatas.Add(new CombatData(defenseType, defense));
        _resistance.DoDamage(new List<CombatData>() { new CombatData(combatType, damage) });
    }

    void TestIfDamageGetsThroughDefense()
    {
        _life.SetHealth(StartHealth);
        int damage = 1;

        _resistance.DoDamage(new List<CombatData>() { new CombatData(CombatType.Fire, damage) });

        Assert.IsTrue(_life.Health == StartHealth - damage, "Testing if damage gets through resistance");
    }

    void TestIfResistanceWithExtraDefenseStopsDamage()
    {
        _life.SetHealth(StartHealth);
        int damage = 2;
        int defense = 3;

        SetupDamageNDefense(damage, defense, CombatType.Fire, CombatType.Fire);

        Assert.IsTrue(_life.Health == StartHealth, "Testing if resistrance with extra defense stops damage");
    }

    void TestIfDifferentDamageTypeThanDefenseDoesDamage()
    {
        _life.SetHealth(StartHealth);
        int damage = 2;
        int defense = 2;

        SetupDamageNDefense(damage, defense, CombatType.Fire, CombatType.Nature);

        Assert.IsTrue(_life.Health == StartHealth - damage, "Testing if different damage types, than defense still does damage");
    }

    void TestIfDoesBaseDamage()
    {
        _life.SetHealth(StartHealth);
        int baseDamage = 2;

        _resistance.DoDamage(new List<CombatData>() { new CombatData(CombatType.BaseType, baseDamage) });

        Assert.IsTrue(_life.Health == StartHealth - baseDamage, "Testing if does base damage");
    }

    


}