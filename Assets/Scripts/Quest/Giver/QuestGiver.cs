using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Quest.Rewards.Spawner;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public sealed class QuestGiver : MonoBehaviour
    {
        public int Id;
        public int UiId;
        public int Health
        {
            get { return _questGiverProperties.Health; }
            set
            {
                if (value <= 0)
                {
                    QuestGiversPool.Remove(this);
                }
            }
        }

        private QuestGiverProperties _questGiverProperties;
        private RewardFactory _rewardFactory;
        private RewardSpawner _rewardSpawner;
        

        public void Init()
        {
            _questGiverProperties = new QuestGiverProperties(Id);
            _questGiverProperties.Rewards = new List<Reward>();
            _rewardFactory = new RewardFactory();
            _rewardSpawner = GameObject.FindGameObjectWithTag("RewardSpawner").GetComponent<RewardSpawner>();
            InitRewards(_questGiverProperties.RewardIds);
            SetRewardUI();
        }

        private void SetRewardUI()
        {
            Camera.main.GetComponent<UIManager>().ActivateItemWithTypeAndId<UiQuestGiver>(UiId);
            Camera.main.GetComponent<UIManager>().SendPropertiesToItemWithTypeAndId<UiQuestGiver>(UiId, _questGiverProperties);
        }

        public void InitRewards(int[] rewardIds)
        {
            XmlSearcher rewardsXmlSearcher = new XmlSearcher(Location.Reward);
            foreach (var rewardId in rewardIds)
            {
                AddRewardsWithId(rewardsXmlSearcher, rewardId);
            }
        }

        private void AddRewardsWithId(XmlSearcher rewardsXmlSearcher, int rewardId)
        {
            XmlNode rewardNode = rewardsXmlSearcher.GetNodeInArrayWithId(rewardId, "Rewards");
            if (rewardNode != null)
            {
                foreach (XmlNode rewardTypeInChildInWithNode in rewardsXmlSearcher.GetChildrensWithName(rewardNode, "Type"))
                {
                    AddRewardWithId(rewardId, rewardTypeInChildInWithNode);
                }
            }
        }

        private void AddRewardWithId(int rewardId, XmlNode rewardTypeInChildInWithNode)
        {
            int rewardTypeId = int.Parse(rewardTypeInChildInWithNode.Attributes["id"].InnerText);
            _questGiverProperties.Rewards.Add(_rewardFactory.GetReward((RewardType) rewardTypeId, rewardId));
        }

        public void SpawnRewards()
        {
            foreach (var reward in _questGiverProperties.Rewards)
            {
                reward.SpawnReward(_rewardSpawner);
            }
        }

    }
}   