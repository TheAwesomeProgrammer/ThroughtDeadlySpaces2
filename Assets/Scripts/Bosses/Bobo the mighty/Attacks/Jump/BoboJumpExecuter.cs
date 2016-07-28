using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboJumpExecuter : BossAttackBase
    {
        private const float StartDelay = 0.5f;

        private const float JumpForce = 10;

        private Rigidbody _boboRigidbody;
        private JumpCollisionDetector _jumpCollisionDetector;

        protected override void Start()
        {
            _baseDamageXmlId = 1;
            base.Start();
            _boboRigidbody = transform.root.FindComponentInChildWithTag<Rigidbody>("EnemyCollision");
            _jumpCollisionDetector = _boboRigidbody.GetComponent<JumpCollisionDetector>();
            _possiblePauseStates.Add(BoboState.Idle);
        }

        protected override void Attack()
        {
            base.Attack();
            Timer.Start(gameObject, StartDelay, Jump);
        }

        void Jump()
        {
            _boboRigidbody.AddRelativeForce(new Vector3(0, 0.4f, 1) * JumpForce, ForceMode.VelocityChange);
            _jumpCollisionDetector.Enable(_baseDamage);
        }

        public override void SwitchState()
        {
            base.SwitchState();
        }
    }
}