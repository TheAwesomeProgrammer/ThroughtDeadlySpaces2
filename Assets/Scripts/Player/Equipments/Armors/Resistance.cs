using System;
using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Armors.ArmorModifier;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using UnityEngine;

public class Resistance : LifeDamager
{
    public List<DefenseData> DefenseDatas { get; set; }
    public event Action Defending;

    private AttributeManager _armorAttributeManager;

    public void Start()
    {
        DefenseDatas = new List<DefenseData>();
        _armorAttributeManager = GetComponent<AttributeManager>();
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

        foreach (var armorReduceModifier in GetSwordDamageModifiers())
        {
            modifiedDefenseData.Defense = ((DefenseData)armorReduceModifier.GetModifiedCombatData(defenseData)).Defense;
        }

        return modifiedDefenseData;
    }

    private ArmorReduceModifier[] GetSwordDamageModifiers()
    {
        return _armorAttributeManager.GetComponentsList<ArmorReduceModifier>().ToArray();
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