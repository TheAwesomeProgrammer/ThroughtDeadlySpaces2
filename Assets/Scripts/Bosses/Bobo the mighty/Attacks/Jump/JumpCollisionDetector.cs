using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class JumpCollisionDetector : CollisionChecking
    {
        private int _damage ;

        private const float AoeLiveTime = 0.25f;
        private BossProjectileSpawner _projectileSpawner;
        private Transform _aoeSpawnPoint;
        private bool _enabled;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Floor");
            _projectileSpawner = GetComponent<BossProjectileSpawner>();
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
                GameObject spawnedObject = _projectileSpawner.Spawn(_aoeSpawnPoint.position, new ProjectileData(_damage));
                Destroy(spawnedObject, AoeLiveTime);
                _enabled = false;
            }
        }
    }
}