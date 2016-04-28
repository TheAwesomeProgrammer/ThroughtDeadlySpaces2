using System;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords.Executes;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Swords
{
    public class BreakingFactory
    {
        public Executeable GetBreakingExecuteable(EquipmentType equipmentType)
        {
            switch (equipmentType)
            {
                case EquipmentType.Sword:
                    return new ArmorBreakingExecute();
                case EquipmentType.Armor:
                    return new SwordBreakingExecute();
                default:
                    throw new ArgumentOutOfRangeException("equipmentType", equipmentType, null);
            }
        }
    }
}