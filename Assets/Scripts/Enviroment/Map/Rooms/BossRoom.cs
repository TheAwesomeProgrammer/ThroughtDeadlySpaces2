using System.Collections.Generic;
using Assets.Scripts.Bosses;
using Assets.Scripts.Quest;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class BossRoom : Room
    {
        public Transform BossSpawnTransform;

        private bool _playerHasEnteredRoom = false;

        public bool IsBossAlive
        {
            get { return GetComponentInChildren<BossStateMachine>() != null; }
        }

        public override void OnPlayerJustEnteredRoom()
        {
            base.OnPlayerJustEnteredRoom();
            QuestGiver aliveQuestGiver = QuestGiversPool.GetAliveQuestGiver();

            if (aliveQuestGiver && !_playerHasEnteredRoom)
            {
                GameObject spawnedBoss = aliveQuestGiver.SpawnBoss(BossSpawnTransform.position);
                spawnedBoss.transform.parent = transform;
                _playerHasEnteredRoom = true;
            }
        }
    }
}