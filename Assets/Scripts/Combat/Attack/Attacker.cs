using System;
using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class Attacker : MonoBehaviour, Attackable
    {
        public event Action AttackStarted;
        public event Action Attacking;
        public event Action AttackEnded;

        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set
            {
                _attackSpeed = Mathf.Clamp(value, MinAttackSpeed, MaxAttackSpeed);
                _damageTrigger.AttackSpeed = _attackSpeed;
                _animator.SetFloat(_animatorAttackSpeedName, _attackSpeed);
            }
        }

        private const float MaxAttackSpeed = 1;
        private const float MinAttackSpeed = 0.276f;
        

        protected EquipmentAttributeManager _equipmentAttributeManager;
        protected List<DamageData> _damageDatas = new List<DamageData>();
        protected bool _attacking;
        protected bool _canAttack;
        protected string _animatorAttackSpeedName = "AttackSpeed";

        private float _attackSpeed;
        private AnimationEventListener _animationEventListener;
        private DamageTrigger _damageTrigger;
        private Animator _animator;

        protected virtual void Start()
        {
            EnableAttack();
            _damageDatas = new List<DamageData>();
            _damageTrigger = GetComponent<DamageTrigger>();
            _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
            _animationEventListener = GetComponent<AnimationEventListener>();
            _animator = GetComponent<AnimatorTrigger>().Animator;
            if (_animationEventListener != null)
            {
                _animationEventListener.SetupAnimatorTrigger(StartAttack, EndAttack);
            }
        }

        public void DeativateAttack()
        {
            _canAttack = false;
        }

        public void EnableAttack()
        {
            _canAttack = true;
        }

        public void StartAttack()
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

        public void EndAttack()
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
            IsAttacking();
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

        public void IsAttacking()
        {
            if (Attacking != null)
            {
                Attacking();
            }
        }

        protected virtual DamageData GetModifiedDamage(DamageData damageData)
        {
            DamageData modfiedDamageData = damageData;

            foreach (var damageModifier in GetDamageModifiers())
            {
                modfiedDamageData.Damage = ((DamageData) damageModifier.GetModifiedCombatData(damageData)).Damage;
            }

            return modfiedDamageData;
        }

        private List<DamageModifier> GetDamageModifiers()
        {
            return _equipmentAttributeManager.GetComponentsList<DamageModifier>();
        }
    }
}