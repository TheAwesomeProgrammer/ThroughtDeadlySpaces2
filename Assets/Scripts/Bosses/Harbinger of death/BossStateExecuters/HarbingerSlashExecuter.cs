using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerSlashExecuter : HarbingerAttackBase
    {
        protected override void Start()
        {
            base.Start();
            _possiblePauseStates = new HarbingerOfDeathState[1]
            {
                HarbingerOfDeathState.Idle
            };
            _baseDamageXmlId = 0;
        }
    }
}