using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class PlayerDash : MonoBehaviour
    {
        private const int StartDashSpeed = 15;
        private const int EndDashSpeed = 5;
        private const int Cost = 1;

        private AnimatorTrigger _animatorTrigger;
        private PlayerMovementController _playerMovementController;
        private Rigidbody _rigidbody;
        private DexterityFiller _dexterityFiller;
        private AbillityTiming _abillityTiming;
        private float _dashSpeed;

        void Start()
        {
            _abillityTiming = GetComponent<AbillityTiming>();
            _playerMovementController = GetComponentInParent<PlayerMovementController>();
            _rigidbody = GetComponentInParent<Rigidbody>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _dexterityFiller = GetComponentInParent<DexterityFiller>();
            _animatorTrigger.AnimationStarting += OnDashAnimationStarting;
            _abillityTiming.AbillityStart += OnAbillityStart;
            _abillityTiming.AbillityUpdate += OnAbillityUpdate;
            _abillityTiming.AbillityEnd += OnAbillityEnd;
        }

        void OnDashAnimationStarting()
        {
            if (_abillityTiming.Active)
            {
                _animatorTrigger.Cancel();
            }
            _abillityTiming.UseAbillity();
        }

        private void OnAbillityStart()
        {
            if (_dexterityFiller.Dexterity >= Cost && _playerMovementController.CanMove)
            {
                _dexterityFiller.Dexterity -= Cost;
                _playerMovementController.CanMove = false;
                LeanTween.value(gameObject, SetDashSpeed, StartDashSpeed, EndDashSpeed, _abillityTiming.Duration);
            }
            else
            {
                _animatorTrigger.Cancel();
            }
        }

        void SetDashSpeed(float speed)
        {
            _dashSpeed = speed;
        }

        private void OnAbillityUpdate()
        {
            Vector3 moveDirection = (-transform.forward * _dashSpeed);
            moveDirection.y = _rigidbody.velocity.y;
            _rigidbody.velocity = moveDirection;
        }

        private void OnAbillityEnd()
        {
            _playerMovementController.CanMove = true;
            _animatorTrigger.End();
        }
    }
}