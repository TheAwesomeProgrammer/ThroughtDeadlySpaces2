using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class EnemyAttacker
    {
        public Collider Collider;

        private Weakness _weakness;
        private float _attackSpeed;
        private float _attackTimer;

        public EnemyAttacker(Collider collider, float attackSpeed)
        {
            Collider = collider;
            _weakness = collider.GetComponent<Weakness>();
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
            _weakness.DoDamage(damageDatas);
        }

        private bool CanAttack()
        {
            return _attackTimer <= Time.time;
        }

        public override bool Equals(object obj)
        {
            EnemyAttacker enemyAttacker = (EnemyAttacker) obj;
            return enemyAttacker.Collider == Collider;
        }
    }
}