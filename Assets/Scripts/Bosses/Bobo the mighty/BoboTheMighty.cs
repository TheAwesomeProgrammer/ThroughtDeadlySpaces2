using Assets.Scripts.Bosses.Harbinger_of_death;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty
{
    public class BoboTheMighty : BossStateMachine
    {
        protected override void DelayedStart()
        {
            base.DelayedStart();
            ChangeState(BoboState.Movement);
        }
    }
}