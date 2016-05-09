using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class LargeHeartPoition : Trigger
    {
        private LargeHeartPotionExecute _largeHeartPotionExecute;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
            _largeHeartPotionExecute = new LargeHeartPotionExecute();
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _largeHeartPotionExecute.Execute(_triggerCollider.gameObject);
        }
    }
}