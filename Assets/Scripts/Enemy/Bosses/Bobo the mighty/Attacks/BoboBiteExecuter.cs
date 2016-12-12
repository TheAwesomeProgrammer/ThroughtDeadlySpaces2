using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Harbinger_of_death;
using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboBiteExecuter : BossAttackBase
    {
        public override string AnimationName
        {
            get { return "BiteBobo"; }
        }

        protected override void Start()
        {
            base.Start();
            _possiblePauseStates = new List<Enum>()
            {
                BoboState.Idle
            };
            _baseDamageXmlId = 0;
        }
    }
}