using System.Collections.Generic;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Abstract
{
    public class BossProjectileSpawner : ProjectileSpawner
    {
        public Difficulty BossDifficulty;

        private EnemyCombatProperties _enemyCombatProperties;

        void Start()
        {
            _enemyCombatProperties = GetComponentInParent<EnemyCombatProperties>();
            if (_enemyCombatProperties != null)
            {
                //BossDifficulty = _enemyCombatProperties.Difficulty;
            }
            _setableDatas.Add(new BossSetExtraBaseDamage());
        }

        protected override GameObject Spawn(Vector3 spawnPosition)
        {
            GameObject spawnedObject = base.Spawn(spawnPosition);

            BossAttack bossAttack = spawnedObject.GetComponentInChildren<BossAttack>();
            if (bossAttack != null && _enemyCombatProperties)
            {
                bossAttack.AddRandomAllocatedDamage((int)BossDifficulty);
            }

            return spawnedObject;
        }

      
    }
}