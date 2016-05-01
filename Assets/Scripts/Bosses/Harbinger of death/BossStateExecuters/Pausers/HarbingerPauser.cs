using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerPauser : XmlLoadable
    {
        private const int BossId = 1;

        private Dictionary<HarbingerOfDeathState, float> WaitTimeSet;

        public HarbingerPauser()
        {
            LoadXml();
        }

        public void LoadXml()
        {
            XmlSearcher xmlSearcher = new XmlSearcher(Location.Boss);
            XmlNode bossNode = xmlSearcher.GetNodeInArrayWithId(BossId, "Bosses");
            WaitTimeSet = new Dictionary<HarbingerOfDeathState, float>()
            {
                {HarbingerOfDeathState.Slash, xmlSearcher.GetSpecsInNodeFloat(bossNode, "PauseTime")[0] },
                {HarbingerOfDeathState.Heavy, xmlSearcher.GetSpecsInNodeFloat(bossNode, "PauseTime")[1] },
                {HarbingerOfDeathState.Beam, xmlSearcher.GetSpecsInNodeFloat(bossNode, "PauseTime")[2] },
                {HarbingerOfDeathState.MultiBeam, xmlSearcher.GetSpecsInNodeFloat(bossNode, "PauseTime")[3] }
            };
        }

        public IEnumerator WaitThenChangeStateToMove(HarbingerOfDeath harbingerOfDeath)
        {
            yield return new WaitForSeconds(WaitTimeSet[harbingerOfDeath.PreviusState]);
            harbingerOfDeath.ChangeState(HarbingerOfDeathState.Movement);
        }
    }
}