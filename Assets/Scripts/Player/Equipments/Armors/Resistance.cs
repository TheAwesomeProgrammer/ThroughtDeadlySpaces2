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

    protected override void Awake()
    {
        DefenseDatas = new List<DefenseData>();
        _armor = GetComponent<Armor>();
        _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
    }

    public void SetupDefenseDamageDatas()
    {
        DefenseDatas.Add(new BaseDefenseData(_armor.Specs.BaseDamage));
        DefenseDatas.Add(new DefenseData(CombatType.Fire, _armor.Specs.FireDamage));
        DefenseDatas.Add(new DefenseData(CombatType.Nature, _armor.Specs.NatureDamage));
        DefenseDatas.Add(new DefenseData(CombatType.Life, _armor.Specs.LifeDamage));
        DefenseDatas.Add(new DefenseData(CombatType.Death, _armor.Specs.DeathDamage));
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