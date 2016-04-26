using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class DexterityPotion : Trigger
    {
        public int DexterityToGive;

        private DexterityPotionExecute _dexterityPotionExecute;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            _dexterityPotionExecute = new DexterityPotionExecute(DexterityToGive);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _dexterityPotionExecute.Execute(_triggerCollider.gameObject);
        }
    }
}