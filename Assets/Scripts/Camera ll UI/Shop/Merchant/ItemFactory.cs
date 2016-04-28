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
            DefaultShopItem defaultShopItem = (DefaultShopItem) shopItem;
            if (defaultShopItem != null)
            {
                switch (defaultShopItem.EquipmentType)
                {
                    case EquipmentType.Sword:
                        return new SwordExecute(defaultShopItem.XmlId);
                    case EquipmentType.Armor:
                        return new ArmorExecute(defaultShopItem.XmlId);
                }
            }

            PotionShopItem potionShopItem = (PotionShopItem) shopItem;
            if (potionShopItem != null)
            {
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