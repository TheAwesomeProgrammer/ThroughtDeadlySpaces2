using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class StrengthPotion : Trigger
    {
        public int StrengthToGive = 1;

        private StrengthPotionExecute _strengthPotionExecute;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            _strengthPotionExecute = new StrengthPotionExecute(StrengthToGive);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _strengthPotionExecute.Execute(_triggerCollider.gameObject);
        }
    }
}