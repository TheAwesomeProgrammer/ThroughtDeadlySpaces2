using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;
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
            Null.OnNot(_life, () => _life.Health -= damageData.Damage);
        }
    }
}