using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Debug
{
    public class SwitchInstaBackToIdle : BossAttackBase
    {
        protected override void Attack()
        {
            base.Attack();
            SwitchState();
        }
    }
}