using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups
{
    public class SwordDrop : Trigger
    {
        public int SwordId;

        private SwordExecute _swordExecute;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
            _swordExecute = new SwordExecute(SwordId);
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _swordExecute.Execute(_triggerCollider.gameObject);
        }
    }
}