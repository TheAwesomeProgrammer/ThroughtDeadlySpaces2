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

        private BossProperties _bossProperties;

        void Start()
        {
            _bossProperties = GetComponentInParent<BossProperties>();
            if (_bossProperties != null)
            {
                BossDifficulty = _bossProperties.Difficulty;
            }
            _setableDatas.Add(new BossSetExtraBaseDamage());
        }

        protected override GameObject Spawn(Vector3 spawnPosition)
        {
            GameObject spawnedObject = base.Spawn(spawnPosition);

            BossAttack bossAttack = spawnedObject.GetComponentInChildren<BossAttack>();
            if (bossAttack != null && _bossProperties)
            {
                bossAttack.AddRandomAllocatedDamage((int)BossDifficulty);
            }

            return spawnedObject;
        }

      
    }
}