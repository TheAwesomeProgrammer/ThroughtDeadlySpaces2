using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Shop
{
    public class ItemBuyer
    {
        private ItemFactory _itemFactory;

        public ItemBuyer()
        {
            _itemFactory = new ItemFactory();
        }

        public void ShouldBuyItem(ShopItem shopItem)
        {
            if (CanBuy(shopItem.Money))
            {
                BuyItem(shopItem);
            }
        }

        private void BuyItem(ShopItem shopItem)
        {
            Executeable executeable = _itemFactory.GetItemExecuteable(shopItem);
            executeable.Execute(GameObject.FindWithTag("Player"));
        }

        private bool CanBuy(int money)
        {
            return MoneyManager.Money >= money;
        }
    }
}