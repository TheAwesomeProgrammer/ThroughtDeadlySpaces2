using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerHeavyExecuter : HarbingerAttackBase
    {
        protected override void Start()
        {
            base.Start();
            _possiblePauseStates = new HarbingerOfDeathState[2]
            {
                HarbingerOfDeathState.Idle, HarbingerOfDeathState.Enraged
            };
            _baseDamageXmlId = 1;
        }
    }
}