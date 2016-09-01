using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Map.Rooms;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Quest.Rewards.Spawner;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public sealed class QuestGiver : MonoBehaviour
    {
        private QuestGiverProperties _questGiverProperties;


        public int Id
        {
            get { return QuestGiverProperties.Id; }
            set
            {
                QuestGiverProperties.Id = value;
            }
        }

        public int UiId
        {
            get { return QuestGiverProperties.UiId; }
            set
            {
                QuestGiverProperties.UiId = value;
            }
        }

        public int Health
        {
            get { return QuestGiverProperties.Health; }
            set
            {
                if (value <= 0)
                {
                    QuestGiversPool.Remove(this);
                }
            }
        }

        public QuestGiverProperties QuestGiverProperties
        {
            get { return _questGiverProperties ?? (_questGiverProperties = new QuestGiverProperties()); }
            set { _questGiverProperties = value; }
        }

        public void Init()
        {

			InitQuestProperties();
            SetQuestUI();
        }

	    private void InitQuestProperties()
	    {
		    QuestGiverProperties.LoadXml();
		    QuestGiverProperties.LoadQuests(Id);
	    }

	    private void SetQuestUI()
        {
            Camera.main.GetComponent<UIManager>().ActivateItemWithTypeAndId<UiQuestGiver>(UiId);
            Camera.main.GetComponent<UIManager>().SendPropertiesToItemWithTypeAndId<UiQuestGiver>(UiId, _questGiverProperties);
        }

        public void SpawnRewardsInRoom(Room room)
        {
            RewardSpawner rewardSpawner = room.GetComponentInChildren<RewardSpawner>();
            foreach (var reward in _questGiverProperties.GetRewards())
            {
	            reward.SpawnReward(rewardSpawner);
            }
        }

        public GameObject SpawnBoss(Vector3 spawnPosition)
        {
            BossGeneratorProperties bossGeneratorProperties = _questGiverProperties.BossGeneratorProperties;
            return bossGeneratorProperties.Spawn(spawnPosition);
        }
    }
}