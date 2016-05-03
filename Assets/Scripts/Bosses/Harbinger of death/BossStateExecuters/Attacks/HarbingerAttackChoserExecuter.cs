using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerAttackChoser : BossAttackChoserBase
    {
        protected override void Start()
        {
            base.Start();
            _possibleAttacks = new HarbingerPossibleAttacks();
        }
    }
}