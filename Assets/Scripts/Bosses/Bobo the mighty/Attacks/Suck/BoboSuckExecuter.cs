using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.Suck
{
    public class BoboSuckExecuter : BossAttackBase
    {
        public GameObject Suck;
        public Transform SuckSpawnpoint;

        private const float StartDelay = 1f;
        private const float Duration = 6f;

        private BoboAttackChoserExecuter _attackChoserExecuter;
        private GameObject _spawnedSuckObject;
        private LookAtTargetXz _lookAtTargetXz;

        protected override void Start()
        {
            base.Start();
            _lookAtTargetXz = transform.root.FindComponentInChildWithTag<LookAtTargetXz>("EnemyCollision");
            _attackChoserExecuter = GetComponentInParent<BoboAttackChoserExecuter>();
            _possiblePauseStates.Add(BoboState.Idle);
            _baseDamageXmlId = 0;
        }

        protected override void Attack()
        {
            base.Attack();
            _lookAtTargetXz.StopLooking();
            Timer.Start(gameObject, StartDelay, StartSucking);
        }

        private void StartSucking()
        {
            SpawnSuckObject();
            SetBoboSuckerProperties();
            Timer.Start(gameObject, Duration, StopSucking);
        }

        private void SpawnSuckObject()
        {
            _spawnedSuckObject = Instantiate(Suck, SuckSpawnpoint.position, Quaternion.identity) as GameObject;
            Vector3 spawnOffset = new Vector3(_spawnedSuckObject.GetComponent<Collider>().bounds.extents.x, 0, 0);
            _spawnedSuckObject.transform.position += spawnOffset;
        }

        private void SetBoboSuckerProperties()
        {
            BoboSucker boboSucker = _spawnedSuckObject.GetComponent<BoboSucker>();
            boboSucker.SuckTransform = SuckSpawnpoint;
            boboSucker.OwnerRigidbody = transform.root.FindComponentInChildWithTag<Rigidbody>("EnemyCollision");
        }

        private void StopSucking()
        {
            _lookAtTargetXz.StopLooking();
            Destroy(_spawnedSuckObject);
            if (_attackChoserExecuter.PlayerInRange)
            {
                _bossStateMachine.ChangeState(BoboState.Bite);
            }
            else
            {
                SwitchState();
            }
        }
    }
}