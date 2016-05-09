using System;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Input;
using Assets.Scripts.Quest;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public class QuestGiverInteractable : InteractableWithButtons
    {
        private UIManager _uiManager;
        private bool _hasUsedInteractable;
        private PlayerMovementChanger _movementChanger;

        protected override void Start()
        {
            base.Start();
            _movementChanger = new PlayerMovementChanger();
            _uiManager = Camera.main.GetComponent<UIManager>();
        }

        public void OnUsedInteractable()
        {
            _hasUsedInteractable = true;
            _movementChanger.StartMovement(_player);
        }

        protected override void OnInteractableButtonDownAndCollidingWithPlayer()
        {
            base.OnInteractableButtonDownAndCollidingWithPlayer();
            if (!_hasUsedInteractable)
            {
                _movementChanger.StopMovement(_player);
                ActivateQuestGivers();
            }
        }

        protected override void OnBackButtonDownAndCollidingWithPlayer()
        {
            base.OnBackButtonDownAndCollidingWithPlayer();
            if (!_hasUsedInteractable)
            {
                _movementChanger.StartMovement(_player);
                _uiManager.DeactivateItemWithType<UiQuestGiver>();
            }
        }

        private void ActivateQuestGivers()
        {
            var questGiversWithRandomIds = QuestGiversPool.GenerateAliveQuestGivers(2);

            for (int i = 0; i < questGiversWithRandomIds.Count; i++)
            {
                questGiversWithRandomIds[i].UiId = i;
                questGiversWithRandomIds[i].Init();
            }
        }
    }
}