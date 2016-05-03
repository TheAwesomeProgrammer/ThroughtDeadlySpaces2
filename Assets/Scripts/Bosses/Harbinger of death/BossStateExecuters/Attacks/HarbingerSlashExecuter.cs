using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerSlashExecuter : BossAttackBase
    {
        protected override void Start()
        {
            base.Start();
            _possiblePauseStates.Add(HarbingerOfDeathState.Idle);
            _baseDamageXmlId = 0;
        }
    }
}