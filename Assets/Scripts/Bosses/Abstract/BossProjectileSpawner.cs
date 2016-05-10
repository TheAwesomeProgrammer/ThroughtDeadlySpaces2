using System.Collections.Generic;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Abstract
{
    public class BossProjectileSpawner : ProjectileSpawner
    {
        private BossProperties _bossProperties;

        void Start()
        {
            _bossProperties = GetComponentInParent<BossProperties>();
            _setableDatas.Add(new BossSetExtraBaseDamage());
        }

        protected override GameObject Spawn(Vector3 spawnPosition)
        {
            GameObject spawnedObject = base.Spawn(spawnPosition);

            BossAttack bossAttack = spawnedObject.GetComponentInChildren<BossAttack>();
            if (bossAttack != null)
            {
                bossAttack.AddRandomAllocatedDamage((int)_bossProperties.Difficulty);
            }

            return spawnedObject;
        }

      
    }
}