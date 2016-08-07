using System;
using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using UnityEngine;

public class Resistance : LifeDamager, Damageable
{
    public List<CombatData> DefenseDatas { get; set; }
    public event Action Defending;

    private EquipmentAttributeManager _equipmentAttributeManager;
    private CombatModifierCaller _combatModifierCaller;
    private Armor _armor;

    protected override void Awake()
    {
        DefenseDatas = new List<CombatData>();
        _armor = GetComponent<Armor>();
        _combatModifierCaller = new CombatModifierCaller();
        _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
    }

    public void SetupDefenseDamageDatas()
    {
        DefenseDatas.Add(new CombatData(CombatType.BaseType, _armor.Specs.BaseDamage));
        DefenseDatas.Add(new CombatData(CombatType.Fire, _armor.Specs.FireDamage));
        DefenseDatas.Add(new CombatData(CombatType.Nature, _armor.Specs.NatureDamage));
        DefenseDatas.Add(new CombatData(CombatType.Life, _armor.Specs.LifeDamage));
        DefenseDatas.Add(new CombatData(CombatType.Death, _armor.Specs.DeathDamage));
    }

    public void DoDamage(List<CombatData> damageDatas)
    {
        if (Defending != null)
        {
            Defending();
        }
        List<CombatData> cloneOfDamageDatas = DefenseDatas.Clone();
        for (int i = 0; i < cloneOfDamageDatas.Count; i++)
        {
            cloneOfDamageDatas[i] = GetModifiedDefense(cloneOfDamageDatas[i]);
        }
        Damage(GetDamageAfterGoingThroughResistance(damageDatas));
    }

    protected virtual CombatData GetModifiedDefense(CombatData defenseData)
    {
        CombatData modifiedDefenseData = defenseData;

        foreach (var attribute in GetAttributes())
        {
            modifiedDefenseData = _combatModifierCaller.GetModifiedData(attribute, defenseData);
        }

        return modifiedDefenseData;
    }

    private EquipmentAttribute[] GetAttributes()
    {
        return _equipmentAttributeManager.GetComponentsList<EquipmentAttribute>().ToArray();
    }

    List<CombatData> GetDamageAfterGoingThroughResistance(List<CombatData> damageDatas)
    {
        foreach (var damageData in damageDatas)
        {
            CombatData defenseData = AreDamageNotGettingThroughResistance(damageData);
            if (defenseData != null)
            {
                damageData.CombatValue -= defenseData.CombatValue;
            }
        }

        return damageDatas;
    }

    private CombatData AreDamageNotGettingThroughResistance(CombatData damageData)
    {
        return DefenseDatas.Find(defenseData => defenseData.Equals(damageData));
    }

    

}