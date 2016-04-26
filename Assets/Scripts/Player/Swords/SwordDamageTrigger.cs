using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordDamageTrigger : Trigger
    {
        private List<Collider> _enemies;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Enemy");
            _enemies = new List<Collider>();
        } 

        public void DoDamage(List<DamageData> damageDatas)
        {
            foreach (var enemy in _enemies)
            {
                Weakness enemyWeakness = enemy.GetComponent<Weakness>();
                enemyWeakness.DoDamage(damageDatas);
            }
        }

        public override void OnStay()
        {
            base.OnStay();
            if (!_enemies.Contains(_triggerCollider))
            {
                _enemies.Add(_triggerCollider);
            }
        }
    }
}