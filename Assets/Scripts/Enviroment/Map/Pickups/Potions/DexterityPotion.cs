using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class DexterityPotion : Pickup
    {
        public int DexterityToGive;

        private DexterityPotionExecute _dexterityPotionExecute;

        protected override void Start()
        {
            base.Start();
            _dexterityPotionExecute = new DexterityPotionExecute(DexterityToGive);
        }

        protected override void OnPickup()
        {
            base.OnPickup();
            _dexterityPotionExecute.Execute(_player);
        }
    }
}