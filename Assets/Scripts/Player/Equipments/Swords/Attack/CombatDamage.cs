using System;
using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [System.Serializable]
    public class CombatDamage
    {
        public Damageable Damageable;
        public float AttackSpeed;
        public event Action<CombatDamage> Attacked;

        private float _attackTimer;

        public CombatDamage(Damageable damageable, float attackSpeed)
        {
            Damageable = damageable;
            AttackSpeed = attackSpeed;
        }

        public void SetAttackSpeed(float newAttackSpeed)
        {
            float attackSpeedDiff = newAttackSpeed - AttackSpeed;
            _attackTimer += attackSpeedDiff;
            AttackSpeed = newAttackSpeed;
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
            if (Attacked != null)
            {
                Attacked(this);
            }
            _attackTimer = Time.time + AttackSpeed;
            Damageable.DoDamage(damageDatas);
        }

        private bool CanAttack()
        {
            return _attackTimer <= Time.time;
        }

        public override bool Equals(object obj)
        {
            CombatDamage combatDamage = (CombatDamage) obj;
            return combatDamage.Damageable == Damageable;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}