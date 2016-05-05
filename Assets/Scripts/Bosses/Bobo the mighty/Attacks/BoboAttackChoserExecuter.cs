using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboAttackChoserExecuter : BossAttackChoserBase
    {
        protected override void Start()
        {
            base.Start();
            _possibleAttacks = new BoboPossibleAttacks();
        }
    }
}