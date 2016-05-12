using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Combat.Attack;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossAttack : Attacker
    {
        public bool AttackOnStart;

        private BaseDamageData _extraBaseDamageData;
        private BossProperties _bossProperties;

        protected override void Start()
        {
            base.Start();
            if (AttackOnStart)
            {
                StartAttack();
            }
            _bossProperties = GetComponentInParent<BossProperties>();
            SetupDamageDatas();
        }

        private void SetupDamageDatas()
        {
            if (_bossProperties != null)
            {
                AddRandomAllocatedDamage((int)_bossProperties.Difficulty);
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
                BaseDamageData baseDamageData = (BaseDamageData)_damageDatas.Find(damageData => damageData is BaseDamageData);
                if (baseDamageData != null)
                {
                    baseDamageData.Damage += damage;
                }
                else
                {
                    _damageDatas.Add(new BaseDamageData(damage));
                }
              
            }
            else if (combatType != CombatType.BaseType)
            {
                _damageDatas.Add(new DamageData(combatType, damage));
            }
        }

        public void SetExtraBaseDamage(int damage)
        {
            _extraBaseDamageData = new BaseDamageData(damage);
        }

        protected override void DoDamage(List<DamageData> damageDatas)
        {
            damageDatas.Add(_extraBaseDamageData);
            base.DoDamage(damageDatas);
        }
    }
}