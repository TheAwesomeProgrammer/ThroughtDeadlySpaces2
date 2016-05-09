using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Quest.Rewards.Spawner;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public abstract class Reward : Rewardable, XmlLoadable
    {
        public XmlNode QuestsNode;
        public int QuestId;
        public int RewardTypeId;

        protected XmlSearcher _xmlSearcher;
        
        protected GameObject _objectSpawned;

        protected int[] RewardSpecs
        {
            get
            {
                List<int> rewardSpecs = new List<int>();

                XmlNode questNode = _xmlSearcher.GetNodeInArrayWithId(QuestId, QuestsNode);
                if (questNode != null)
                {
                    rewardSpecs.AddRange(_xmlSearcher.GetSpecsInNodeWithId(RewardTypeId, questNode));
                }

                return rewardSpecs.ToArray();
            }
        }

        protected Reward(int rewardTypeId, int questId, XmlNode questsNode)
        {
            RewardTypeId = rewardTypeId;
            QuestId = questId;
            QuestsNode = questsNode;
            _xmlSearcher = new XmlSearcher(Location.QuestGiver);
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