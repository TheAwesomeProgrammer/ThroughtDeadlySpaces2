using Assets.Scripts.Shop;
using Assets.Scripts.Shop.Merchant;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class ShopButton : UiButton
    {
        private ItemBuyer _itemBuyer;

        protected override void Start()
        {
            base.Start();
            _itemBuyer = new ItemBuyer();
        }

        protected override void OnClick()
        {
            base.OnClick();
            _itemBuyer.ShouldBuyItem(GetComponent<ShopItem>());
        }
    }
}