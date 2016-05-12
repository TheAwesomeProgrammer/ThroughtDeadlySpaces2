using Assets.Scripts.Movement.Pushing;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class JumpBelowItemsMover : BelowItemsMover
    {
        protected override void Start()
        {
            base.Start();
            Tags.Add(Tag.PlayerCollision);
        }
    }
}