using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class DamageTrigger : Trigger
    {
        private const float AttackSpeed = 1;

        private List<EnemyAttacker> _enemyAttackers;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Enemy");
            _enemyAttackers = new List<EnemyAttacker>();
        } 

        public void DoDamage(List<DamageData> damageDatas)
        {
            foreach (var enemyAttacker in _enemyAttackers)
            {
                enemyAttacker.ShouldAttack(damageDatas);
            }
        }

        public override void OnStay()
        {
            base.OnStay();
            EnemyAttacker newEnemyAttacker = new EnemyAttacker(_triggerCollider, AttackSpeed);
            if (!_enemyAttackers.Contains(newEnemyAttacker))
            {
                _enemyAttackers.Add(newEnemyAttacker);
            }
        }
    }
}