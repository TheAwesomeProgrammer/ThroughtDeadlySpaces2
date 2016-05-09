using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class StrengthPotion : Pickup
    {
        public int StrengthToGive = 1;

        private StrengthPotionExecute _strengthPotionExecute;

        protected override void Start()
        {
            base.Start();
            _strengthPotionExecute = new StrengthPotionExecute(StrengthToGive);
        }

        protected override void OnPickup()
        {
            base.OnPickup();
            _strengthPotionExecute.Execute(_player);
        }
    }
}