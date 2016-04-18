using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense;
using UnityEngine;

public class Resistance : LifeDamager
{
    public List<DefenseData> DefenseDatas { get; set; }

    protected void Start()
    {
        DefenseDatas = new List<DefenseData>();
    }

    public void DoDamage(List<DamageData> damageDatas)
    {
        Damage(GetDamageAfterGoingThroughResistance(damageDatas));
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
        return DefenseDatas.Find(defenseData => defenseData.Equals(damageData) && damageData.CombatType != CombatType.BaseType);
    }

    

}