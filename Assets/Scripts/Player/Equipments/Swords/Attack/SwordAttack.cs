using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordAttack : SwordComponent
    {
        public event Action AttackStarted;
        public event Action Attacking;
        public event Action AttackEnded;

        private List<DamageData> _damageDatas = new List<DamageData>();
        private PlayerProperties _playerProperties;
        private SwordDamageTrigger _swordDamageTrigger;
        private AnimatorTrigger _animatorTrigger;
        
        private bool _canAttack;

        protected override void Start()
        {
            base.Start();
            _damageDatas = new List<DamageData>();
            _swordDamageTrigger = GetComponent<SwordDamageTrigger>();
            _playerProperties = GetComponentInParent<PlayerProperties>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            SetupAnimatorTrigger();
            SetupDamageDatas();
        }

        void SetupAnimatorTrigger()
        {
            _animatorTrigger.AnimationStarted += OnAttackStarted;
            _animatorTrigger.AnimationEnded += OnAttackEnded;
        }

        void OnAttackStarted()
        {
            _canAttack = true;
            if (AttackStarted != null)
            {
                AttackStarted();
            }
        }

        void OnAttackEnded()
        {
            _canAttack = false;
            if (AttackEnded != null)
            {
                AttackEnded();
            }
        }

        void SetupDamageDatas()
        {
            _damageDatas.Add(new BaseDamageData(_sword.Specs.BaseDamage));
            _damageDatas.Add(new DamageData(CombatType.Type1, _sword.Specs.CombatType1Damage));
            _damageDatas.Add(new DamageData(CombatType.Type2, _sword.Specs.CombatType2Damage));
            _damageDatas.Add(new DamageData(CombatType.Type3, _sword.Specs.CombatType3Damage));
            _damageDatas.Add(new DamageData(CombatType.Type4, _sword.Specs.CombatType4Damage));
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

        void Update()
        {
            if (_canAttack)
            {
                Attack();
            }
        }

        public void AddStrength(int strength)
        {
            _damageDatas.Find(damageData => damageData.CombatType == CombatType.BaseType).Damage += strength;
        }

        public virtual List<DamageData> Attack()
        {
            OnAttack();
            List<DamageData> cloneOfDamageDatas = _damageDatas.Clone();
            for (int i = 0; i < cloneOfDamageDatas.Count; i++)
            {
                cloneOfDamageDatas[i] = GetModifiedDamage(cloneOfDamageDatas[i]);
            }
            _swordDamageTrigger.DoDamage(cloneOfDamageDatas);
            return cloneOfDamageDatas;
        }

        void OnAttack()
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

        private SwordDamageModifier[] GetSwordDamageModifiers()
        {
            return _swordAttributeManager.GetComponentsList<SwordDamageModifier>().ToArray();
        }

    }
}