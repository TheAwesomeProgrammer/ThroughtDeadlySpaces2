using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class BossHarbingerMovementExecuter : MonoBehaviour, BossStateExecuter
    {
        private const float TimeToFollow = 3;

        private FollowTargetWithRotation _followTargetWithRotation;
        private Transform _playerTransform;
        private HarbingerOfDeath _harbingerOfDeath;

        void Start()
        {
            _followTargetWithRotation = GetComponentInParent<FollowTargetWithRotation>();
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void SwitchToAttacking()
        {
            _followTargetWithRotation.StopMoving();
            _harbingerOfDeath.ChangeState(HarbingerOfDeathState.Attack);
        }

        public void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _followTargetWithRotation.SetTarget(_playerTransform);
            _harbingerOfDeath = harbingerOfDeath;
            Timer.Start(TimeToFollow, gameObject, "SwitchToAttacking");
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {
            _followTargetWithRotation.StopMoving();
        }
    }
}