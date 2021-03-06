﻿using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Managers;
using Assets.Scripts.Player.Swords.Abstract;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Shop.Merchant
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
            executeable.Execute(GameObject.FindWithTag(Tag.Player));
        }

        private bool CanBuy(int money)
        {
            return MoneyManager.Money >= money;
        }
    }
}