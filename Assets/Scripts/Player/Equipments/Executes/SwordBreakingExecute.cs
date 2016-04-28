using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords.Curses;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Executes
{
    public class SwordBreakingExecute : Executeable
    {
        public void Execute(GameObject gameObject)
        {
            gameObject.AddComponent<BrokenSwordCurse>();
        }
    }
}