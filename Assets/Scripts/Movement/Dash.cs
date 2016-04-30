using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class Dash : MonoBehaviour
    {
        public Animator Animator;

        private const float DashTime = 0.5f;
        private const int StartDashSpeed = 15;
        private const int EndDashSpeed = 5;
        private const string DashTriggerEndName = "DashEnd";

        private AnimatorTrigger _animatorTrigger;
        private PlayerMovement _playerMovement;
        private CharacterController _characterController;
        private float _dashTimer = int.MinValue;
        private float _dashSpeed;
        private bool _dashing;

        void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _characterController = GetComponent<CharacterController>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _animatorTrigger.AnimationStarted += OnDashAnimationStarted;
        }

        void OnDashAnimationStarted()
        {
            _dashTimer = 0;
            _dashing = true;
            _playerMovement.CanMove = false;
            LeanTween.value(gameObject, SetDashSpeed, StartDashSpeed, EndDashSpeed, DashTime);
        }

        void Update()
        {
            if (_dashing)
            {
                _characterController.Move(-transform.forward * _dashSpeed * Time.deltaTime);
            }
            if (_dashTimer > DashTime && _dashing)
            {
                _dashing = false;
                _playerMovement.CanMove = true;
                Animator.SetTrigger(DashTriggerEndName);
            }

            _dashTimer += Time.deltaTime;
        }

        void SetDashSpeed(float speed)
        {
            _dashSpeed = speed;
        }
    }
}