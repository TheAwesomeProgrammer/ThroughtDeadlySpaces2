using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Movement;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboRapidFrenzyExecuter : BossAttackBase
    {
        private const float ExtraSpeed = 10;
        private const float Duration = 2;

        private LookAtTargetXz _lookAtTargetXz;
        private MoveForward _moveForward;
        private ContinuousPusher _continuousPusher;
        private WallStopChecker _wallStopChecker;
        private float _startSpeed;

        public override string AnimationName
        {
            get { return "RapidWithoutStart"; }
        }

        protected override void Start()
        {
            _baseDamageXmlId = 4;
            base.Start();
            GetBoboComponents();
            GetFrenzyComponents();
            _possiblePauseStates.Add(BoboState.Idle);
        }

        private void GetBoboComponents()
        {
            _moveForward = GetComponentInParent<MoveForward>();
            _lookAtTargetXz = GetComponentInParent<LookAtTargetXz>();
        }

        private void GetFrenzyComponents()
        {
            Transform frenzyAttackTransform = transform.root.FindChildByTag("FrenzyAttack");
            _bossAttack = frenzyAttackTransform.GetComponentInChildren<BossAttack>();
            _continuousPusher = frenzyAttackTransform.GetComponentInChildren<ContinuousPusher>();
            _wallStopChecker = GetComponentInParent<WallStopChecker>();
        }

        protected override void Attack()
        {
            base.Attack();
            _wallStopChecker.CollidingWithWall += SwitchState;
            _lookAtTargetXz.StopLooking();
            StartMoving();
            StartAttacking();
            Timer.Start(gameObject, Duration, SwitchState);
        }

        private void StartMoving()
        {
            _moveForward.StartMoving();
            _startSpeed = _moveForward.Speed;
            _moveForward.Speed += ExtraSpeed;
            _continuousPusher.StartContinuousPushing();
        }

        private void StartAttacking()
        {
            _bossAttack.StartAttack();
            _bossAttack.SetExtraBaseDamage(_baseDamage);
        }

        public override void SwitchState()
        {
            base.SwitchState();
            _wallStopChecker.CollidingWithWall -= SwitchState;
            _bossAttack.EndAttack();
            StopMoving();
            _animatorTrigger.End();
        }

        private void StopMoving()
        {
            _continuousPusher.StopContinuousPushing();
            _lookAtTargetXz.StartLooking();
            _moveForward.StopMoving();
            _moveForward.Speed = _startSpeed;
        }
    }
}