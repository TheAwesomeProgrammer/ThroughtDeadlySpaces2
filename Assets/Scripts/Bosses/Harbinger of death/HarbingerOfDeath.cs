using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public class HarbingerOfDeath : BossStateMachine
    {
        protected override void Start()
        {
            base.Start();
            _bossStateExecuterFactory = GetComponentInChildren<HarbingerStateExecuterFactory>();
        }

        protected override void DelayedStart()
        {
            base.DelayedStart();
            ChangeState(HarbingerOfDeathState.Movement);
        }
    }
}