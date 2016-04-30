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
            if (CollidingWithPlayer())
            {
                OnInteractableButtonDownAndCollidingWithPlayer();
            }
        }

        private void ShouldCallBackButtonDown()
        {
            if (CollidingWithPlayer())
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

        private bool CollidingWithPlayer()
        {
            return CollisionType != CollisionType.NoCollision;
        }
    }
}