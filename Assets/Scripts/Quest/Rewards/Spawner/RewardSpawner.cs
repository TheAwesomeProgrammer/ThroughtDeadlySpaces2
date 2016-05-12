using Assets.Scripts.Enviroment.Map.Rooms;
using Assets.Scripts.Quest.Rewards.Potion;
using Assets.Scripts.Quest.Rewards.Sword;
using UnityEngine;

namespace Assets.Scripts.Quest.Rewards.Spawner
{
    public class RewardSpawner : MonoBehaviour
    {
        public GameObject Money;

        private RewardPotionObjectFactory _rewardPotionObjectFactory;
        private RewardSwordObjectFactory _rewardSwordObjectFactory;
        private BaseRoom _roomParent;
        private Vector3 _offset;
        private Collider _collider;
        private CircleOffsetCalculator _circleOffsetCalculator;

        void Awake()
        {
            _rewardPotionObjectFactory = GetComponent<RewardPotionObjectFactory>();
            _rewardSwordObjectFactory = GetComponent<RewardSwordObjectFactory>();
            _roomParent = GetComponentInParent<BaseRoom>();
            _offset = Vector3.zero;
            _circleOffsetCalculator = new CircleOffsetCalculator();
        }

        public void ResetCircleOffset()
        {
            _circleOffsetCalculator.Reset();
        }

        public GameObject SpawnWithCircleOffset(Reward reward)
        {
            GameObject spawnedObject = SpawnWithNoOffset(reward);

            _collider = spawnedObject.GetComponent<Collider>();
            spawnedObject.transform.position += _circleOffsetCalculator.GetOffset(_collider);
            return spawnedObject;
        }

        public GameObject SpawnWithNoOffset(Reward reward)
        {
            Vector3 spawnPosition = _roomParent.RewardSpawnTransform.position;
            GameObject spawnedObject = null;

            if (reward is RewardSword)
            {
                RewardSword rewardSword = (RewardSword) reward;
                spawnedObject = Instantiate(_rewardSwordObjectFactory.GetElement(rewardSword.SwordId), spawnPosition + _offset, Quaternion.identity) as GameObject;
            }
            else if (reward is RewardMoney)
            {
                spawnedObject = Instantiate(Money, spawnPosition + _offset, Quaternion.identity) as GameObject;
            }
            else if (reward is RewardPotion)
            {
                RewardPotion rewardPotion = (RewardPotion) reward;
                spawnedObject = Instantiate(_rewardPotionObjectFactory.GetElement((int)rewardPotion.PotionType), spawnPosition + _offset, Quaternion.identity) as GameObject;
                
            }

            return spawnedObject;
        }
    }
}