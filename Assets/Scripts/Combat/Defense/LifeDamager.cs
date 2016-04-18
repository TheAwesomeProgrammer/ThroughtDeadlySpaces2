using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Defense
{
    public class LifeDamager : MonoBehaviour
    {
        protected Life _life;

        protected virtual void Awake()
        {
            _life = GetComponent<Life>();
        }
      

        protected virtual void Damage(List<DamageData> damageDatas)
        {
            foreach (var damageData in damageDatas)
            {
                Damage(damageData);
            }
        }

        protected virtual void Damage(DamageData damageData)
        {
            _life.Health -= damageData.Damage;
        }
    }
}