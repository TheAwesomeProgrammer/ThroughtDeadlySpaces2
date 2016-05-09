using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms.EventTriggers
{
    public class CheckPlayerInRoom : Trigger
    {
        private Room _roomInParent;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
            _roomInParent = GetComponentInParent<Room>();
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (!_roomInParent.IsPlayerInRoom)
            {
                _roomInParent.IsPlayerInRoom = true;
                _roomInParent.OnPlayerJustEnteredRoom();
            }
        }

        public override void OnExitWithTag()
        {
            base.OnExitWithTag();
            _roomInParent.IsPlayerInRoom = false;
        }
    }
}