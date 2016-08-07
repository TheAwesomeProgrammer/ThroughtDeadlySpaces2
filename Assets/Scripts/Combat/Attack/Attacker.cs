using System;
using System.Collections.Generic;
using Assets.Scripts.Combat;
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

        protected EquipmentAttributeManager _equipmentAttributeManager;
        protected List<CombatData> _damageDatas = new List<CombatData>();
        protected bool _attacking;
        protected bool _canAttack;
        protected string _animatorAttackSpeedName = "AttackSpeed";
        protected DamageTrigger _damageTrigger;

        private AnimationEventListener _animationEventListener;
        private CombatModifierCaller _combatModifierCaller;

        protected virtual void Start()
        {
            EnableAttack();
            _combatModifierCaller = new CombatModifierCaller();
            _damageDatas = new List<CombatData>();
            _damageTrigger = GetComponent<DamageTrigger>();
            _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
            _animationEventListener = GetComponent<AnimationEventListener>();
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
                _damageTrigger.ClearAttackers();
                if (AttackEnded != null)
                {
                    AttackEnded();
                }
            }
        }

        public void AddDamageDatas(List<CombatData> damageDatas)
        {
            _damageDatas.AddRange(damageDatas);
        }

        public void AddDamageData(CombatData damageData)
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

        public virtual List<CombatData> Attack()
        {
            IsAttacking();
            List<CombatData> cloneOfDamageDatas = _damageDatas.Clone();
            for (int i = 0; i < cloneOfDamageDatas.Count; i++)
            {
                cloneOfDamageDatas[i] = GetModifiedDamage(cloneOfDamageDatas[i]);
            }
            DoDamage(cloneOfDamageDatas);
            return cloneOfDamageDatas;
        }

        protected virtual void DoDamage(List<CombatData> damageDatas)
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

        protected virtual CombatData GetModifiedDamage(CombatData damageData)
        {
            CombatData modfiedDamageData = damageData;

            foreach (var damageModifier in GetDamageModifiers())
            {
                modfiedDamageData = _combatModifierCaller.GetModifiedData(damageModifier, damageData);
            }

            return modfiedDamageData;
        }

        private List<EquipmentAttribute> GetDamageModifiers()
        {
            return _equipmentAttributeManager.GetComponentsList<EquipmentAttribute>();
        }
    }
}