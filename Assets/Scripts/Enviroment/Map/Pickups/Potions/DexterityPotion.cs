using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
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
            Tags.Add(Tag.PlayerCollision);
            _dexterityPotionExecute = new DexterityPotionExecute(DexterityToGive);
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _dexterityPotionExecute.Execute(_triggerCollider.gameObject);
        }
    }
}