using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms.EventTriggers
{
    public class EnterDoorEventTrigger : EventTrigger
    {
        public Door Door;

        protected override void Start()
        {
            base.Start();
            TriggerOnEnter = true;
            Tags.Add(Tag.PlayerCollision);
        }

        protected override void DoEvent()
        {
            Door.OnEnteredDoor();
        }
    }
}