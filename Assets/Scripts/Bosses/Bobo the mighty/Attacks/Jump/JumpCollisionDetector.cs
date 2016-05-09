﻿using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class JumpCollisionDetector : CollisionChecking
    {
        private int _damage ;

        private const float AoeLiveTime = 0.25f;
        private ProjectileSpawner _projectileSpawner;
        private Transform _aoeSpawnPoint;
        private bool _enabled;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Floor");
            _projectileSpawner = GetComponent<ProjectileSpawner>();
            _aoeSpawnPoint = transform.FindChild("JumpAoeSpawnPoint");
        }

        public void Enable(int damage)
        {
            _damage = damage;
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (_enabled)
            {
                GameObject spawnedObject = _projectileSpawner.Spawn(_aoeSpawnPoint.position,
                    new BossSetExtraBaseDamage(), new ProjectileData(_damage));
                Destroy(spawnedObject, AoeLiveTime);
            }
        }
    }
}