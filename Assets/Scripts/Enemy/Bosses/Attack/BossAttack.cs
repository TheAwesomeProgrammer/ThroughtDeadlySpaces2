using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player.Equipments;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossAttack : Attacker
    {
        public bool AttackOnStart;

        private CombatData _extraBaseDamageData;
        private EnemyCombatProperties _enemyCombatProperties;

        protected override void Start()
        {
            base.Start();
            if (AttackOnStart)
            {
                StartAttack();
            }
            _enemyCombatProperties = GetComponentInParent<EnemyCombatProperties>();
            SetupDamageDatas();
        }

        private void SetupDamageDatas()
        {
            if (_enemyCombatProperties != null)
            {
                //AddRandomAllocatedDamage((int)_enemyCombatProperties.Difficulty);
            }
            AddRandomAllocatedDamage(LevelManager.CurrentLevel);
        }

        public void AddRandomAllocatedDamage(int damage)
        {
            int damagePerRound = 1;
            for (int i = 0; i < damage; i++)
            {
                AddDamageData((CombatType)Random.Range(0, Enum.GetNames(typeof(CombatType)).Length), damagePerRound);
            }
        }

        private void AddDamageData(CombatType combatType, int damage)
        {
            if (combatType == CombatType.BaseType)
            {
                CombatData baseDamageData = _damageDatas.Find(damageData => damageData.CombatType == CombatType.BaseType);
                if (baseDamageData != null)
                {
                    baseDamageData.CombatValue += damage;
                }
                else
                {
                    _damageDatas.Add(new CombatData(CombatType.BaseType, damage));
                }
              
            }
            else if (combatType != CombatType.BaseType)
            {
                _damageDatas.Add(new CombatData(combatType, damage));
            }
        }

        public void SetExtraBaseDamage(int damage)
        {
            _extraBaseDamageData = new CombatData(CombatType.BaseType, damage);
        }

        protected override void DoDamage(List<CombatData> damageDatas)
        {
            damageDatas.Add(_extraBaseDamageData);
            base.DoDamage(damageDatas);
        }
    }
}