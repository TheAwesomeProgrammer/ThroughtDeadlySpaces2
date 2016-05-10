using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Shop;
using Assets.Scripts.Shop.BlackSmith;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public class BlackSmithInteractable : InteractableWithButtons
    {
        public int ShopUiId = 1;

        private UIManager _uiManager;
        private PlayerMovementChanger _movementChanger;

        protected override void Start()
        {
            base.Start();
            _movementChanger = new PlayerMovementChanger();
            _uiManager = Camera.main.GetComponent<UIManager>();
        }

        protected override void OnInteractableButtonDownAndCollidingWithPlayer()
        {
            base.OnInteractableButtonDownAndCollidingWithPlayer();
            _uiManager.ActivateItemWithTypeAndId<UiShop>(ShopUiId);
            _uiManager.SelectUiItemWithTypeAndId<RepairItem>(15);
            _movementChanger.StopMovement(_player);
        }

        protected override void OnBackButtonDownAndCollidingWithPlayer()
        {
            base.OnBackButtonDownAndCollidingWithPlayer();
            _uiManager.DeactivateItemWithTypeAndId<UiShop>(ShopUiId);
            _movementChanger.StartMovement(_player);
        }
    }
}