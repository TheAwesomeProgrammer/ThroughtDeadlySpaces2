using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerPauser
    {
        private Dictionary<HarbingerOfDeathState, float> WaitTimeSet;

        public HarbingerPauser()
        {
            WaitTimeSet = new Dictionary<HarbingerOfDeathState, float>()
            {
                {HarbingerOfDeathState.Slash, 0.5f},
                {HarbingerOfDeathState.Heavy, 3f},
                {HarbingerOfDeathState.Beam, 3f},
                {HarbingerOfDeathState.MultiBeam, 4f}
            };
        }

        public IEnumerator WaitThenChangeStateToMove(HarbingerOfDeath harbingerOfDeath)
        {
            yield return new WaitForSeconds(WaitTimeSet[harbingerOfDeath.PreviusState]);
            harbingerOfDeath.ChangeState(HarbingerOfDeathState.Movement);
        }
    }
}