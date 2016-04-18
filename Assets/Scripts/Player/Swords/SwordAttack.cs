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
        public int StandardDamage = 1;

        public event Action Attacking;

        private List<DamageData> _damageDatas;
        private PlayerProperties _playerProperties;
        private SwordDamageTrigger _swordDamageTrigger;

        protected override void Start()
        {
            base.Start();
            _damageDatas = new List<DamageData>();
            _swordDamageTrigger = GetComponent<SwordDamageTrigger>();
            SetupDamageDatas();
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

        public void ClearDamageDatas()
        {
            _damageDatas.Clear();
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
                modfiedDamageData.Damage = swordDamageModifier.GetModifiedDamageData(damageData).Damage;
            }

            return modfiedDamageData;
        }

        private SwordDamageModifier[] GetSwordDamageModifiers()
        {
            return _sword.GetSwordComponents<SwordDamageModifier>().ToArray();
        }

    }
}