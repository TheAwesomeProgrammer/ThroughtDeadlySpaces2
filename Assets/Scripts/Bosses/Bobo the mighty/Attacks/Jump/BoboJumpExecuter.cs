using Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks
{
    public class BoboJumpExecuter : BossAttackBase
    {
        public GameObject AoePusher;

        private const float StartDelay = 1f;

        private const float JumpForce = 2000;

        private Rigidbody _boboRigidbody;
        private JumpCollisionDetector _jumpCollisionDetector;

        protected override void Start()
        {
            _baseDamageXmlId = 1;
            base.Start();
            _boboRigidbody = transform.root.FindComponentInChildWithTag<Rigidbody>("Collision");
            _jumpCollisionDetector = _boboRigidbody.GetComponent<JumpCollisionDetector>();
            _possiblePauseStates.Add(BoboState.Idle);
        }

        protected override void Attack()
        {
            base.Attack();
            Timer.Start(StartDelay, Jump);
            //Instantiate(AoePusher, transform.position, Quaternion.identity);
        }

        void Jump()
        {
            _boboRigidbody.AddRelativeForce(new Vector3(0, 0.4f, 1) * JumpForce, ForceMode.Impulse);
            _jumpCollisionDetector.Enable(_baseDamage);
        }

        public override void SwitchState()
        {
            base.SwitchState();
            _jumpCollisionDetector.Disable();
        }
    }
}