using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerBeamExecuter : HarbingerAttackBase
    {
        private BossBeam _bossBeam;

        protected override void Start()
        {
            base.Start();
            _bossBeam = transform.root.FindComponentInChildWithName<BossBeam>("Beam");
            _bossSwordAttack = transform.root.FindComponentInChildWithName<BossSwordAttack>("Beam");
            _possiblePauseStates = new HarbingerOfDeathState[1]
            {
                HarbingerOfDeathState.Enraged
            };
            _baseDamageXmlId = 2;
        }

        protected override void Attack()
        {
            base.Attack();
            _bossBeam.OnAttackStarted(SwitchState);
        }
    }
}