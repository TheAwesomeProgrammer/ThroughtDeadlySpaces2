using System;
using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossSwordAttack : Attacker
    {
        private BaseDamageData _extraBaseDamageData;

        protected override void Start()
        {
            base.Start();
            SetupDamageDatas();
        }

        private void SetupDamageDatas()
        {
            for (int i = 0; i < LevelManager.CurrentLevel; i++)
            {
                AddDamageData((CombatType)Random.Range(0, Enum.GetNames(typeof(CombatType)).Length), 1);
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