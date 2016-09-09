using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Quest.Rewards.Spawner;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public abstract class Reward : Rewardable, XmlLoadable
    {
        public XmlNode QuestsNode;
        public int QuestId;
        public int RewardTypeId;
        public int QuestGiverId;
        
        protected GameObject _objectSpawned;
        protected XmlPath _rewardTypePath;

        protected int[] RewardSpecs
        {
            get
            {
                List<int> rewardSpecs = new List<int>();

                _rewardTypePath = new DefaultXmlPath(XmlLocation.QuestGiver, new XmlPathData(QuestGiverId),
                    new XmlPathData(XmlName.QuestRoot),
                    new XmlPathData(QuestId),
                    new XmlPathData(RewardTypeId));
             
                rewardSpecs.AddRange(_rewardTypePath.GetSpecs());
                return rewardSpecs.ToArray();
            }
        }

        protected Reward(int rewardTypeId, int questId, int questGiverId)
        {
            RewardTypeId = rewardTypeId;
            QuestId = questId;
            QuestGiverId = questGiverId;

            if (IsValid())
	        {
		        LoadXml();
	        }
        }

	    public virtual bool IsValid()
	    {
		    return true;
	    }

        public abstract void LoadXml();

        public virtual void SpawnReward(RewardSpawner rewardSpawner)
        {
            _objectSpawned = rewardSpawner.SpawnWithCircleOffset(this);
        }

        public abstract override string ToString();
    }
}