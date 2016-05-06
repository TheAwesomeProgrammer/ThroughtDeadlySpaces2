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
        private const float Duration = 4.5f;

        private BoboAttackChoserExecuter _attackChoserExecuter;
        private GameObject _spawnedSuckObject;
        private LookAtTargetXz _lookAtTargetXz;
        private bool _shouldSwitch;

        protected override void Start()
        {
            base.Start();
            _lookAtTargetXz = transform.root.FindComponentInChildWithTag<LookAtTargetXz>("Collision");
            _attackChoserExecuter = GetComponentInParent<BoboAttackChoserExecuter>();
            _possiblePauseStates.Add(BoboState.Idle);
            _baseDamageXmlId = 2;
        }

        protected override void Attack()
        {
            base.Attack();
            _shouldSwitch = true;
            _lookAtTargetXz.StopLooking();
            Timer.Start(StartDelay, StartSucking);
        }

        private void StartSucking()
        {
            _spawnedSuckObject = Instantiate(Suck, SuckSpawnpoint.position, Quaternion.identity) as GameObject;
            _spawnedSuckObject.transform.position += new Vector3(_spawnedSuckObject.GetComponent<Collider>().bounds.extents.x, 0, 0);
            SetBoboSuckerProperties();
            Timer.Start(Duration, StopSucking);
        }

        private void SetBoboSuckerProperties()
        {
            BoboSucker boboSucker = _spawnedSuckObject.GetComponent<BoboSucker>();
            boboSucker.SuckTransform = SuckSpawnpoint;
            boboSucker.OwnerRigidbody = transform.root.FindComponentInChildWithTag<Rigidbody>("Collision");
        }

        private void StopSucking()
        {
            _lookAtTargetXz.StopLooking();
            Destroy(_spawnedSuckObject);
            if (_attackChoserExecuter.PlayerInRange)
            {
                _bossStateMachine.ChangeState(BoboState.Bite);
                _shouldSwitch = false;
            }
        }

        public override void SwitchState()
        {
            if (_shouldSwitch)
            {
                base.SwitchState();
            }
        }
    }
}