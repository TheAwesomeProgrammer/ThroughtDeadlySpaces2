using System.Collections.Generic;
using Assets.Scripts.Quest;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class BaseRoom : Room
    {
        public Transform RewardSpawnTransform;
        public bool SpawnOnPlayerEnter = true;

        private bool _hasEnteredRoom;

        public override void OnPlayerJustEnteredRoom()
        {
            if (!_hasEnteredRoom && SpawnOnPlayerEnter)
            {
                base.OnPlayerJustEnteredRoom();
                QuestGiver questGiver = QuestGiversPool.GetAliveQuestGiver();
                if (questGiver)
                {
                    questGiver.SpawnRewardsInRoom(this);
                }
                _hasEnteredRoom = true;
            }
        }
    }
}