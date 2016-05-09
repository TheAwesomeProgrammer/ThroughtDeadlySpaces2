using System.Collections.Generic;
using Assets.Scripts.Quest;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class BaseRoom : Room
    {
        public Transform RewardSpawnTransform;

        public override void OnPlayerJustEnteredRoom()
        {
            base.OnPlayerJustEnteredRoom();
            QuestGiver questGiver = QuestGiversPool.GetAliveQuestGiver();
            if (questGiver)
            {
                questGiver.SpawnRewards();
            }
        }
    }
}