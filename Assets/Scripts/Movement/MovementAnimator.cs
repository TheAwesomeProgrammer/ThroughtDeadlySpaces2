using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class MovementAnimator : MonoBehaviour
    {
        public const string SpeedAnimatorVariableName = "Speed";

        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimatorSpeed(Vector3 moveDirection)
        {
            _animator.SetFloat(SpeedAnimatorVariableName, moveDirection.magnitude);
        }
    }
}