using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Combat.Defense
{
    public class OneShotDefense : LifeDamager, Damageable
    {
        public void DoDamage(List<DamageData> damageDatas)
        {
            Damage(damageDatas);
        }
    }
}