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

        public override void OnEnter()
        {
            base.OnEnter();
            _roomInParent.IsPlayerInRoom = true;
        }

        public override void OnExit()
        {
            base.OnExit();
            _roomInParent.IsPlayerInRoom = false;
        }
    }
}