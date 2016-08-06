using System.Collections.Generic;
using Assets.Scripts.Bosses;
using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Enviroment.Map.Bridge;
using Assets.Scripts.Quest;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class BossRoom : Room
    {
        public Transform BossSpawnTransform;

        private bool _playerHasEnteredRoom = false;
        private UiSwitchManager _bossDropdownBar;

        public bool IsBossAlive
        {
            get { return GetComponentInChildren<BossStateMachine>() != null; }
        }

        protected override void Start()
        {
            base.Start();
            _bossDropdownBar = Camera.main.GetComponentInChildren<UiBossDropSwitching>();
            MoveToNextRoom += gameObject1 => _bossDropdownBar.Switch();
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
                _bossDropdownBar.Switch();
            }
        }
    }
}