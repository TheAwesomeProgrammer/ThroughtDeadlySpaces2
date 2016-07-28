using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    public class ActivateNextBridgeTrigger : Trigger
    {
        private Room _room;
        private Room _nextRoom;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
            _room = GetComponentInParent<Room>();
            _room.MoveToNextRoom += OnMovedToNextRoom;
        }

        private void OnMovedToNextRoom(GameObject roomObject)
        {
            _nextRoom = roomObject.GetComponent<Room>();
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (_nextRoom != null)
            {
                BridgeManager bridgeManager = _nextRoom.GetComponentInChildren<BridgeManager>();
                bridgeManager.ActivateBridge();
            }
        }
    }
}