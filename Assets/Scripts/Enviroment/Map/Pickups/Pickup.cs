using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups
{
    public class Pickup : Trigger
    {
        protected GameObject _player;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
        }

        protected virtual void OnPickup()
        {
            
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _player = _triggerCollider.transform.root.gameObject;
            OnPickup();
            Destroy(gameObject);
        }
    }
}