using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Enviroment.Map.Bridge;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms.EventTriggers
{
    public class SetBridgeState : Trigger
    {
        public bool ActivateBridge;

        private BridgeManager _bridgeManager;
        private bool _hasMovedToNextRoom;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
            Room myRoom = GetComponentInParent<Room>();
            myRoom.MoveToNextRoom += OnMovedToNextRoom;
            _bridgeManager = myRoom.GetComponentInChildren<BridgeManager>();
        }

        private void OnMovedToNextRoom(GameObject nextRoomObject)
        {
            _hasMovedToNextRoom = true;
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (ActivateBridge && _hasMovedToNextRoom)
            {
                _bridgeManager.ActivateBridge();
            }
            else if(!ActivateBridge)
            {
                _bridgeManager.DeactivateBridge();
            }
        }
    }
}