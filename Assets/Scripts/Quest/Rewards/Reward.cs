using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Quest.Rewards.Spawner;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public abstract class Reward : Rewardable, XmlLoadable
    {
        public int RewardTypeId;
        public int RewardId;

        protected XmlSearcher _xmlSearcher;
        
        protected GameObject _objectSpawned;

        protected int[] RewardSpecs
        {
            get
            {
                List<int> rewardSpecs = new List<int>();

                XmlNode rewardNode = _xmlSearcher.GetNodeInArrayWithId(RewardId, "Rewards");
                if (rewardNode != null)
                {
                    rewardSpecs.AddRange(_xmlSearcher.GetSpecsInNodeWithId(RewardTypeId, rewardNode));
                }

                return rewardSpecs.ToArray();
            }
        }

        protected Reward(int rewardTypeId, int rewardId)
        {
            RewardTypeId = rewardTypeId;
            RewardId = rewardId;
            _xmlSearcher = new XmlSearcher(Location.Reward);
            LoadXml();
        }

        public abstract void LoadXml();

        public virtual void SpawnReward(RewardSpawner rewardSpawner)
        {
            _objectSpawned = rewardSpawner.SpawnWithCircleOffset(this);
        }

        public abstract override string ToString();
    }
}