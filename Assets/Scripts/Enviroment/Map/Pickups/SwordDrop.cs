using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups
{
    public class SwordDrop : Pickup
    {
        public int SwordId;

        private SwordExecute _swordExecute;

        protected override void Start()
        {
            base.Start();
            _swordExecute = new SwordExecute(SwordId);
        }

        protected override void OnPickup()
        {
            base.OnPickup();
            _swordExecute.Execute(_player);
        }
    }
}