using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms.EventTriggers
{
    public class ExitDoorEventTrigger : EventTrigger
    {
        public Door Door;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
            TriggerOnExit = true;
        }

        protected override void DoEvent()
        {
            Door.OnExitedDoor();
        }
    }
}