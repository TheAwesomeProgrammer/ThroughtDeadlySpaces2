using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Armor.Curses;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Executes
{
    public class ArmorBreakingExecute : Executeable
    {
        public void Execute(GameObject gameObject)
        {
            gameObject.AddComponent<ArmorBrokenCurse>();
        }
    }
}