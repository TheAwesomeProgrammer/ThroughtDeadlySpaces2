using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;

namespace Assets.Scripts.Player.Swords
{
    public abstract class DamageTrigger : Trigger
    {
        protected List<CombatAttacker> _enemyAttackers;
        private const float AttackSpeed = 1;

        protected override void Start()
        {
            base.Start();
            _enemyAttackers = new List<CombatAttacker>();
        }

        public void DoDamage(List<DamageData> damageDatas)
        {
            foreach (var enemyAttacker in _enemyAttackers)
            {
                enemyAttacker.ShouldAttack(damageDatas);
            }
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
            CombatAttacker newCombatAttacker = new CombatAttacker(damageable, AttackSpeed);
            if (!_enemyAttackers.Contains(newCombatAttacker))
            {
                _enemyAttackers.Add(newCombatAttacker);
            }
        }
    }
}