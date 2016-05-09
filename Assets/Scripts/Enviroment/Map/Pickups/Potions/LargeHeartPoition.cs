using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class LargeHeartPoition : Pickup
    {
        private LargeHeartPotionExecute _largeHeartPotionExecute;

        protected override void Start()
        {
            base.Start();
            _largeHeartPotionExecute = new LargeHeartPotionExecute();
        }

        protected override void OnPickup()
        {
            base.OnPickup();
            _largeHeartPotionExecute.Execute(_player);
        }
    }
}