using System;
using System.Collections.Generic;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class DamageTrigger : Trigger
    {
        public event Action<CombatDamage> _newEnemyAdded;

        protected List<CombatDamage> _enemyAttackers;

        private float _attackSpeed;

        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set
            {
                _attackSpeed = value;
                _enemyAttackers.ForEach(item => item.SetAttackSpeed(value));
            }
        }

        protected override void Start()
        {
            base.Start();
            _enemyAttackers = new List<CombatDamage>();
        }

        public void DoDamage(List<CombatData> damageDatas)
        {
            foreach (var enemyAttacker in _enemyAttackers)
            {
                enemyAttacker.ShouldAttack(damageDatas);
            }
        }

        public void ClearAttackers()
        {
            _enemyAttackers.Clear();
        }

        public override void OnStayWithTag()
        {
            base.OnStayWithTag();
            if (ShouldCheckTag())
            {
                AddEnemy();
            }
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (ShouldCheckTag())
            {
                AddEnemy();
            }
        }

        private bool ShouldCheckTag()
        {
            return Tags.Count > 0;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (!ShouldCheckTag())
            {
                AddEnemy();
            }
        }

        public override void OnStay()
        {
            base.OnStay();
            if (!ShouldCheckTag())
            {
                AddEnemy();
            }
        }

        protected void AddEnemy()
        {
            Damageable damageable = _triggerCollider.GetComponent<Damageable>();
            if (damageable != null)
            {
                AddCombatAttacker(damageable);
            }
        }

        private void AddCombatAttacker(Damageable damageable)
        {
            CombatDamage newCombatDamage = new CombatDamage(damageable, AttackSpeed);
            if (!_enemyAttackers.Contains(newCombatDamage))
            {
                _newEnemyAdded.CallIfNotNull(newCombatDamage);
                _enemyAttackers.Add(newCombatDamage);
            }
        }
    }
}