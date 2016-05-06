using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class SpeedPotion : Trigger
    {
        public int SpeedToGive = 1;

        private SpeedPotionExecute _speedPotionExecute;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            _speedPotionExecute = new SpeedPotionExecute(SpeedToGive);
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _speedPotionExecute.Execute(_triggerCollider.gameObject);
        }
    }
}