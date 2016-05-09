using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Map.Rooms;
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
        private XmlNode _questGiverNode;
        private XmlSearcher _xmlSearcher;
        private BossGenerator _bossGenerator;
        private Map _map;

        public void Init()
        {
            _map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
            _questGiverProperties = new QuestGiverProperties(Id) { QuestPropertieses = new List<QuestProperties>() };
            _bossGenerator = GameObject.FindWithTag("Scripts").GetComponent<BossGenerator>();
            _rewardFactory = new RewardFactory();
            _xmlSearcher = new XmlSearcher(Location.QuestGiver);
            _questGiverNode = _xmlSearcher.GetNodeInArrayWithId(Id, "QuestGivers");
            InitQuests(_questGiverProperties.RewardIds);
            SetQuestUI();
        }

        private void SetQuestUI()
        {
            Camera.main.GetComponent<UIManager>().ActivateItemWithTypeAndId<UiQuestGiver>(UiId);
            Camera.main.GetComponent<UIManager>().SendPropertiesToItemWithTypeAndId<UiQuestGiver>(UiId, _questGiverProperties);
        }

        public void InitQuests(int[] questsIds)
        {
            foreach (var questId in questsIds)
            {
                AddRewardsWithId(questId);
            }
        }

        private void AddRewardsWithId(int rewardsId)
        {
            XmlNode questsNode = _xmlSearcher.SelectChildNode(_questGiverNode, "Quests");
            XmlNode rewardNode = _xmlSearcher.GetNodeInArrayWithId(rewardsId, questsNode);
            if (rewardNode != null)
            {
                foreach (XmlNode rewardTypeInChildInWithNode in _xmlSearcher.GetChildrensWithName(rewardNode, "Type"))
                {
                    AddQuestWithId(rewardsId, rewardTypeInChildInWithNode, questsNode);
                }
            }
        }

        private void AddQuestWithId(int rewardId, XmlNode rewardTypeInChildInWithNode, XmlNode questsNode)
        {
            int rewardTypeId = int.Parse(rewardTypeInChildInWithNode.Attributes["id"].InnerText);
            Reward reward = _rewardFactory.GetReward((RewardType) rewardTypeId, rewardId, questsNode);
            var bossGeneratorProperties = GetBossGeneratorProperties(rewardId, questsNode);
            _questGiverProperties.AddReward(rewardId, reward, bossGeneratorProperties);
        }

        private BossGeneratorProperties GetBossGeneratorProperties(int rewardId, XmlNode questsNode)
        {
            BossSpawnType bossSpawnType =
                (BossSpawnType) _xmlSearcher.GetSpecsInChildrenWithId(rewardId, questsNode, "BossSpawn")[0];
            BossGeneratorProperties bossGeneratorProperties = _bossGenerator.GetBoss(bossSpawnType);
            return bossGeneratorProperties;
        }

        public void SpawnRewards()
        {
            Room activeRoom = _map.GetActiveRoom();
            RewardSpawner rewardSpawner = activeRoom.GetComponentInChildren<RewardSpawner>();
            foreach (var quest in _questGiverProperties.QuestPropertieses)
            {
                quest.Reward.SpawnReward(rewardSpawner);
            }
        }

        public GameObject SpawnBoss(Vector3 spawnPosition)
        {
            BossGeneratorProperties bossGeneratorProperties = _questGiverProperties.BossGeneratorProperties;
            return Instantiate(bossGeneratorProperties.Boss, spawnPosition, Quaternion.identity) as GameObject;
        }
    }
}   