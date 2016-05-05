using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class DamageTrigger : Trigger
    {
        private const float AttackSpeed = 1;

        protected List<CombatAttacker> _enemyAttackers;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Enemy");
            _enemyAttackers = new List<CombatAttacker>();
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
            CombatAttacker newCombatAttacker = new CombatAttacker(_triggerCollider, AttackSpeed);
            if (!_enemyAttackers.Contains(newCombatAttacker))
            {
                _enemyAttackers.Add(newCombatAttacker);
            }
        }
    }
}