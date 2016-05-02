using Assets.Scripts.Movement;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class BossHarbingerMovementExecuter : MonoBehaviour, BossStateExecuter, XmlLoadable
    {
        private const int BossId = 1;
        private float _timeToFollow;

        private MoveForward _moveForward;
        private Transform _playerTransform;
        private HarbingerOfDeath _harbingerOfDeath;
        private XmlSearcher _xmlSearcher;

        void Start()
        {
            _moveForward = GetComponentInParent<MoveForward>();
            LoadXml();
        }

        public void LoadXml()
        {
            _xmlSearcher = new XmlSearcher(Location.Boss);
            float[] specs = _xmlSearcher.GetSpecsInChildrenWithIdFloat(BossId, "Bosses", "Movement");
            _moveForward.Speed = specs[0];
            _timeToFollow = specs[1];
        }

        void SwitchToAttacking()
        {
            _moveForward.StopMoving();
            _harbingerOfDeath.ChangeState(HarbingerOfDeathState.Attack);
        }

        public void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _harbingerOfDeath = harbingerOfDeath;
            _moveForward.StartMoving();
            Timer.Start(_timeToFollow, gameObject, "SwitchToAttacking");
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {
            _moveForward.StopMoving();
        }
    }
}