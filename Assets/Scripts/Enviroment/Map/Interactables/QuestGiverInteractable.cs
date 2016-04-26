using System;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Input;
using Assets.Scripts.Quest;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public class QuestGiverInteractable : Trigger
    {
        private InputButton _interactableButton;
        private InputButton _backButton;
        private UIManager _uiManager;
        private bool _hasUsedInteractable;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            _uiManager = Camera.main.GetComponent<UIManager>();
            _interactableButton = transform.FindComponentInChildWithName<InputButton>("InteractableButton");
            _backButton = transform.FindComponentInChildWithName<InputButton>("BackButton");
            _interactableButton.ButtonDown += OnInteractableButtonDown;
            _backButton.ButtonDown += OnBackButtonDown;
        }

        public void OnUsedInteractable()
        {
            _hasUsedInteractable = true;
            StartPlayerMovement();
        }

        void OnInteractableButtonDown()
        {
            if (CollidingWithPlayer() && !_hasUsedInteractable)
            {
                StopPlayerMovement();
                ActivateQuestGivers();
            }
        }

        private void StopPlayerMovement()
        {
            _triggerCollider.GetComponent<PlayerMovement>().CanMove = false;
        }

        private bool CollidingWithPlayer()
        {
            return CollisionType != CollisionType.NoCollision;
        }

        void OnBackButtonDown()
        {
            if (CollidingWithPlayer() && !_hasUsedInteractable)
            {
                StartPlayerMovement();
                _uiManager.DeactivateItemWithType<UiQuestGiver>();
            }
        }

        private void StartPlayerMovement()
        {
            _triggerCollider.GetComponent<PlayerMovement>().CanMove = true;
        }

        private void ActivateQuestGivers()
        {
            var questGiversWithRandomIds = QuestGiversPool.GetQuestGivers(2);

            for (int i = 0; i < questGiversWithRandomIds.Count; i++)
            {
                questGiversWithRandomIds[i].UiId = i;
                questGiversWithRandomIds[i].Init();
            }
        }
    }
}