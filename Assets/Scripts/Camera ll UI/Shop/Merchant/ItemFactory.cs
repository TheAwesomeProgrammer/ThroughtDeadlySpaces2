using System;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Quest;
using Assets.Scripts.Shop.Merchant;

namespace Assets.Scripts.Shop.Merchant
{
    public class ItemFactory
    {
        public Executeable GetItemExecuteable(ShopItem shopItem)
        {
            if (shopItem is DefaultShopItem)
            {
                DefaultShopItem defaultShopItem = (DefaultShopItem)shopItem;
               
                switch (defaultShopItem.EquipmentType)
                {
                    case EquipmentType.Sword:
                        return new SwordExecute(defaultShopItem.XmlId);
                    case EquipmentType.Armor:
                        return new ArmorExecute(defaultShopItem.XmlId);
                }
            }

            if (shopItem is PotionShopItem)
            {
                PotionShopItem potionShopItem = (PotionShopItem) shopItem;

                switch (potionShopItem.PotionType)
                {
                    case PotionType.Speed:
                        return new SpeedPotionExecute(potionShopItem.AmountToGive);
                    case PotionType.Strength:
                        return new StrengthPotionExecute(potionShopItem.AmountToGive);
                    case PotionType.Dexterity:
                        return new DexterityPotionExecute(potionShopItem.AmountToGive);
                }
            }

            return new EmptyExecute();
        }
    }
}