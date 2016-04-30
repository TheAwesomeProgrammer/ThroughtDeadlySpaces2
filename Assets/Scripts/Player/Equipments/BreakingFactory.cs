using System;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Executes;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Swords
{
    public class BreakingFactory
    {
        public Executeable GetBreakingExecuteable(Equipment equipment)
        {
            if (equipment is Sword)
            {
                return new SwordBreakingExecute();
            }
            else if (equipment is Armor)
            {
                return new ArmorBreakingExecute();
            }

            return null;
        }
    }
}