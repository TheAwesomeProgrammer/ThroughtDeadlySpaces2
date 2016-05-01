using System;
using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;

namespace Assets.Scripts.Player.Swords
{
    public abstract class Attacker : SwordComponent
    {
        public event Action AttackStarted;
        public event Action Attacking;
        public event Action AttackEnded;

        protected List<DamageData> _damageDatas = new List<DamageData>();

        private DamageTrigger _damageTrigger;
        protected bool _attacking;
        protected bool _canAttack;
        private AnimationEventListener _animationEventListener;

        protected override void Start()
        {
            base.Start();
            StartAttack();
            _damageDatas = new List<DamageData>();
            _damageTrigger = GetComponent<DamageTrigger>();
            _animationEventListener = GetComponent<AnimationEventListener>();
            _animationEventListener.SetupAnimatorTrigger(OnAttackStarting, OnAttackEnded);
        }

        public void StopAttack()
        {
            _canAttack = false;
        }

        public void StartAttack()
        {
            _canAttack = true;
        }

        public void OnAttackStarting()
        {
            if (_canAttack)
            {
                _attacking = true;
                if (AttackStarted != null)
                {
                    AttackStarted();
                }
            }
        }

        public void OnAttackEnded()
        {
            if (_canAttack)
            {
                _attacking = false;
                if (AttackEnded != null)
                {
                    AttackEnded();
                }
            }
        }

        public void AddDamageDatas(List<DamageData> damageDatas)
        {
            _damageDatas.AddRange(damageDatas);
        }

        public void AddDamageData(DamageData damageData)
        {
            _damageDatas.Add(damageData);
        }

        public void ClearDamageDatas()
        {
            _damageDatas.Clear();
        }

        private void Update()
        {
            if (_attacking && _canAttack)
            {
                Attack();
            }
        }

        public virtual List<DamageData> Attack()
        {
            OnAttack();
            List<DamageData> cloneOfDamageDatas = _damageDatas.Clone();
            for (int i = 0; i < cloneOfDamageDatas.Count; i++)
            {
                cloneOfDamageDatas[i] = GetModifiedDamage(cloneOfDamageDatas[i]);
            }
            DoDamage(cloneOfDamageDatas);
            return cloneOfDamageDatas;
        }

        protected virtual void DoDamage(List<DamageData> damageDatas)
        {
            _damageTrigger.DoDamage(damageDatas);
        }

        protected void OnAttack()
        {
            if (Attacking != null)
            {
                Attacking();
            }
        }

        protected virtual DamageData GetModifiedDamage(DamageData damageData)
        {
            DamageData modfiedDamageData = damageData;

            foreach (var swordDamageModifier in GetSwordDamageModifiers())
            {
                modfiedDamageData.Damage = ((DamageData) swordDamageModifier.GetModifiedCombatData(damageData)).Damage;
            }

            return modfiedDamageData;
        }

        private List<DamageModifier> GetSwordDamageModifiers()
        {
            return _swordAttributeManager.GetComponentsList<DamageModifier>();
        }
    }
}