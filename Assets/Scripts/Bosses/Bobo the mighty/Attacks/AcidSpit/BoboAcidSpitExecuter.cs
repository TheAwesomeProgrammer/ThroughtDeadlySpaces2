using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using Assets.Scripts.Combat.Attack.Projectile;
using Assets.Scripts.Combat.Attack.Projectile.Data;
using Assets.Scripts.Combat.Attack.Projectile.DataSetters;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.AcidSpit
{
    public class BoboAcidSpitExecuter : BossAttackBase, ObjectSpawnerable
    {
        public Transform AcidSpawnTransform;

        private LookAtTargetXz _lookAtTargetXz;
        private BossProjectileSpawner _projectileSpawner;
        private GameObject _spawnedAcid;

        protected override void Start()
        {
            _baseDamageXmlId = 3;
            base.Start();
            _projectileSpawner = GetComponent<BossProjectileSpawner>();
            _lookAtTargetXz = transform.root.GetComponentInChildren<LookAtTargetXz>();
            _possiblePauseStates.Add(BoboState.Idle);
        }

        protected override void Attack()
        {
            base.Attack();
            _lookAtTargetXz.StopLooking();
            _spawnedAcid = Spawn(AcidSpawnTransform.position);
        }

        public override void SwitchState()
        {
            Destroy(_spawnedAcid);
            _lookAtTargetXz.StartLooking();
            _bossStateMachine.ChangeState(BoboState.Movement);
        }

        public GameObject Spawn(Vector3 spawnPosition)
        {
            return _projectileSpawner.Spawn(spawnPosition, new ProjectileData(_baseDamage));
        }
    }
}