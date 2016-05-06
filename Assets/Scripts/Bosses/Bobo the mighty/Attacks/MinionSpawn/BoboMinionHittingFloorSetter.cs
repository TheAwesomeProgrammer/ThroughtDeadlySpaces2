using Assets.Scripts.Movement;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboMinionHittingFloorSetter : CollisionChecking
    {
        private AnimatorTrigger _animatorTrigger;
        private MoveForward _moveForward;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Floor");
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _moveForward = GetComponent<MoveForward>();
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _animatorTrigger.StartAnimation();
            _moveForward.enabled = true;
        }
    }
}