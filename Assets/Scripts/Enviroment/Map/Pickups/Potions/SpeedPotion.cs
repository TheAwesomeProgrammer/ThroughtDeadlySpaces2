using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class SpeedPotion : Pickup
    {
        public int SpeedToGive = 1;

        private SpeedPotionExecute _speedPotionExecute;

        protected override void Start()
        {
            base.Start();
            _speedPotionExecute = new SpeedPotionExecute(SpeedToGive);
        }

        protected override void OnPickup()
        {
            base.OnPickup();
            _speedPotionExecute.Execute(_player);
        }
    }
}