using System;
using Assets.Scripts.Shop.BlackSmith.MoneyLoaders;

namespace Assets.Scripts.Shop.BlackSmith
{
    public class RarityMoneyLoaderFactory
    {
        public MoneyLoadable GetRarityMoneyLoader(EquipmentType equipmentType)
        {
            switch (equipmentType)
            {
                case EquipmentType.Sword:
                    return new RaritySwordMoneyLoader();
                case EquipmentType.Armor:
                    return new RarityArmorMoneyLoader();
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", equipmentType, null);
            }
        }
    }
}