using System;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class WallStopChecker : CollisionChecking
    {
        public event Action CollidingWithWall;

        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.Wall);
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (CollidingWithWall != null)
            {
                CollidingWithWall();
            }
        }
    }
}