using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.Movement
{
    public class HarbingerMovement : BossMovementExecuter
    {
        protected override void Start()
        {
            base.Start();
            _attackState = HarbingerOfDeathState.Attack;
        }
    }
}