using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Movement
{
    public class BoboMovement : BossMovementExecuter
    {
        protected override void Start()
        {
            base.Start();
            _attackState = BoboState.Attack;
        }
    }
}