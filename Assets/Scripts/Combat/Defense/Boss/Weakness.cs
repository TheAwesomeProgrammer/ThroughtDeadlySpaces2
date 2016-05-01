using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Defense.Boss
{
    public class Weakness : LifeDamager, Damageable
    {
        public List<CombatType> Weaknesses;

        protected void Start()
        {
            Weaknesses = new List<CombatType>();
        }

        public void DoDamage(List<DamageData> damageDatas)
        {
            Damage(GetDamageDatasHittingWeaknesses(damageDatas));
        }

        List<DamageData> GetDamageDatasHittingWeaknesses(List<DamageData> damageDatas)
        {
            List<DamageData> damageDatasHittingWeaknesses = new List<DamageData>();

            foreach (var damageData in damageDatas)
            {
                if (IsDamageDataHittingWeakness(damageData))
                {
                    damageDatasHittingWeaknesses.Add(damageData);
                }
            }

            return damageDatasHittingWeaknesses;
        }

        bool IsDamageDataHittingWeakness(DamageData damageData)
        {
            return Weaknesses.Contains(damageData.CombatType) || damageData.CombatType == CombatType.BaseType;
        }
    }
}