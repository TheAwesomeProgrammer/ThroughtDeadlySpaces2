using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [System.Serializable]
    public class CombatAttacker
    {
        public Damageable Damageable;

        private float _attackSpeed;
        private float _attackTimer;

        public CombatAttacker(Damageable damageable, float attackSpeed)
        {
            Damageable = damageable;
            _attackSpeed = attackSpeed;
        }

        public void ShouldAttack(List<DamageData> damageDatas)
        {
            if (CanAttack())
            {
                Attack(damageDatas);
            }
        }

        private void Attack(List<DamageData> damageDatas)
        {
            _attackTimer = Time.time + _attackSpeed;
            Damageable.DoDamage(damageDatas);
        }

        private bool CanAttack()
        {
            return _attackTimer <= Time.time;
        }

        public override bool Equals(object obj)
        {
            CombatAttacker combatAttacker = (CombatAttacker) obj;
            return combatAttacker.Damageable == Damageable;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}