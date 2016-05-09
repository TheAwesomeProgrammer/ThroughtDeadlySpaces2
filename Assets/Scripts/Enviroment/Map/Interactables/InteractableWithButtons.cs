using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public abstract class InteractableWithButtons : Trigger
    {
        private InputButton _interactableButton;
        private InputButton _backButton;

        protected GameObject _player;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            _interactableButton = transform.FindComponentInChildWithName<InputButton>("InteractableButton");
            _backButton = transform.FindComponentInChildWithName<InputButton>("BackButton");
            _interactableButton.ButtonDown += ShouldCallInteractableButtonDown;
            _backButton.ButtonDown += ShouldCallBackButtonDown;
        }

        private void ShouldCallInteractableButtonDown()
        {
            if (_player != null)
            {
                OnInteractableButtonDownAndCollidingWithPlayer();
            }
        }

        private void ShouldCallBackButtonDown()
        {
            if (_player != null)
            {
                OnBackButtonDownAndCollidingWithPlayer();
            }
        }

        protected virtual void OnInteractableButtonDownAndCollidingWithPlayer()
        {
         
        }

        protected virtual void OnBackButtonDownAndCollidingWithPlayer()
        {
          
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _player = _triggerCollider.gameObject;
        }

        public override void OnExitWithTag()
        {
            base.OnExitWithTag();
            _player = null;
        }
    }
}