using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms.EventTriggers
{
    public class CheckPlayerInRoom : Trigger
    {
        private Room _roomInParent;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            _roomInParent = GetComponentInParent<Room>();
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _roomInParent.IsPlayerInRoom = true;
        }

        public override void OnExitWithTag()
        {
            base.OnExitWithTag();
            _roomInParent.IsPlayerInRoom = false;
        }
    }
}