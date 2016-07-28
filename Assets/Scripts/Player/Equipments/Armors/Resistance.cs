using System;
using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Armors.ArmorModifier;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using UnityEngine;

public class Resistance : LifeDamager, Damageable
{
    public List<DefenseData> DefenseDatas { get; set; }
    public event Action Defending;

    private EquipmentAttributeManager _equipmentAttributeManager;
    private Armor _armor;

    public void Start()
    {
        DefenseDatas = new List<DefenseData>();
        _armor = GetComponent<Armor>();
        SetupDefenseDamageDatas();
        _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
    }

    void SetupDefenseDamageDatas()
    {
        DefenseDatas.Add(new BaseDefenseData(_armor.Specs.BaseDamage));
        DefenseDatas.Add(new DefenseData(CombatType.Type1, _armor.Specs.CombatType1Damage));
        DefenseDatas.Add(new DefenseData(CombatType.Type2, _armor.Specs.CombatType2Damage));
        DefenseDatas.Add(new DefenseData(CombatType.Type3, _armor.Specs.CombatType3Damage));
        DefenseDatas.Add(new DefenseData(CombatType.Type4, _armor.Specs.CombatType4Damage));
    }

    public void DoDamage(List<DamageData> damageDatas)
    {
        if (Defending != null)
        {
            Defending();
        }
        List<DefenseData> cloneOfDamageDatas = DefenseDatas.Clone();
        for (int i = 0; i < cloneOfDamageDatas.Count; i++)
        {
            cloneOfDamageDatas[i] = GetModifiedDefense(cloneOfDamageDatas[i]);
        }
        Damage(GetDamageAfterGoingThroughResistance(damageDatas));
    }

    protected virtual DefenseData GetModifiedDefense(DefenseData defenseData)
    {
        DefenseData modifiedDefenseData = defenseData;

        foreach (var armorReduceModifier in GetArmorReduceModifiers())
        {
            modifiedDefenseData.Defense = ((DefenseData)armorReduceModifier.GetModifiedCombatData(defenseData)).Defense;
        }

        return modifiedDefenseData;
    }

    private ArmorReduceModifier[] GetArmorReduceModifiers()
    {
        return _equipmentAttributeManager.GetComponentsList<ArmorReduceModifier>().ToArray();
    }

    List<DamageData> GetDamageAfterGoingThroughResistance(List<DamageData> damageDatas)
    {
        foreach (var damageData in damageDatas)
        {
            DefenseData defenseData = AreDamageNotGettingThroughResistance(damageData);
            if (defenseData != null)
            {
                damageData.Damage -= defenseData.Defense;
            }
        }

        return damageDatas;
    }

    private DefenseData AreDamageNotGettingThroughResistance(DamageData damageData)
    {
        return DefenseDatas.Find(defenseData => defenseData.Equals(damageData));
    }

    

}