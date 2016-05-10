using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboMinionSpawnExecuter : BossAttackBase
    {
        public Transform MinionSpawnPoint;

        private const float MinionSpawnSpeed = 20;
        private const int MinionsToSpawn = 3;
        private const float MinionSpawnDelay = 1.75f;

        private BossProjectileSpawner _projectileSpawner;
        private int _minionsSpawned;

        protected override void Start()
        {
            base.Start();
            _projectileSpawner = GetComponent<BossProjectileSpawner>();
            _possiblePauseStates.Add(BoboState.Idle);
            _baseDamageXmlId = 2;
        } 

        protected override void Attack()
        {
            base.Attack();
            _minionsSpawned = 0;
            Timer.Start(MinionSpawnDelay, SpawnMinions);
        }

        private void SpawnMinions()
        {
            if (IsLastMinionToSpawn())
            {
                SpawnMinion();
                SwitchState();
            }
            else if (_minionsSpawned < MinionsToSpawn)
            {
                StartAnimation();
                SpawnMinion();
                Timer.Start(MinionSpawnDelay, SpawnMinions);
            }
            
            _minionsSpawned++;
        }

        private bool IsLastMinionToSpawn()
        {
            return _minionsSpawned + 1 >= MinionsToSpawn;
        }

        private void SpawnMinion()
        {
            GameObject spawnedProjectile = _projectileSpawner.Spawn(MinionSpawnPoint.position, new SetMinionBoboDamage(),
                new ProjectileData(_baseDamage));
            AddSpawnSpeed(spawnedProjectile);
        }

        private static void AddSpawnSpeed(GameObject spawnedProjectile)
        {
            Rigidbody projectileRigidbody = spawnedProjectile.GetComponentInChildren<Rigidbody>();
            projectileRigidbody.AddRelativeForce(Vector3.forward*MinionSpawnSpeed, ForceMode.Impulse);
        }
    }
}