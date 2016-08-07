using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Defense.Boss
{
    public class Weakness : LifeDamager, Damageable
    {
        public List<CombatType> Weaknesses { get; set; }

        protected void Start()
        {
            Weaknesses = new List<CombatType>();
        }

        public void DoDamage(List<CombatData> damageDatas)
        {
            Damage(GetDamageDatasHittingWeaknesses(damageDatas));
        }

        List<CombatData> GetDamageDatasHittingWeaknesses(List<CombatData> damageDatas)
        {
            List<CombatData> damageDatasHittingWeaknesses = new List<CombatData>();

            foreach (var damageData in damageDatas)
            {
                if (IsDamageDataHittingWeakness(damageData))
                {
                    damageDatasHittingWeaknesses.Add(damageData);
                }
            }

            return damageDatasHittingWeaknesses;
        }

        bool IsDamageDataHittingWeakness(CombatData damageData)
        {
            return Weaknesses.Contains(damageData.CombatType) || damageData.CombatType == CombatType.BaseType;
        }
    }
}