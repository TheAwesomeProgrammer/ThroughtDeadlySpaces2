using Assets.Scripts.Movement;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class BossHarbingerMovementExecuter : MonoBehaviour, BossStateExecuter, XmlLoadable
    {
        private const int BossId = 1;
        private float _timeToFollow;

        private FollowTargetWithRotation _followTargetWithRotation;
        private Transform _playerTransform;
        private HarbingerOfDeath _harbingerOfDeath;
        private XmlSearcher _xmlSearcher;

        void Start()
        {
            _followTargetWithRotation = GetComponentInParent<FollowTargetWithRotation>();
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            LoadXml();
        }

        public void LoadXml()
        {
            _xmlSearcher = new XmlSearcher(Location.Boss);
            float[] specs = _xmlSearcher.GetSpecsInChildrenWithIdFloat(BossId, "Bosses", "Movement");
            _followTargetWithRotation.Speed = specs[0];
            _timeToFollow = specs[1];
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
            Timer.Start(_timeToFollow, gameObject, "SwitchToAttacking");
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {
            _followTargetWithRotation.StopMoving();
        }
    }
}