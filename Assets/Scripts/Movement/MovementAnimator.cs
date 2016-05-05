using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class MovementAnimator : MonoBehaviour
    {
        public string SpeedAnimatorVariableName = "Speed";
        public Animator Animator;
        public bool AutoSet = false;

        
        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            if (Animator == null)
            {
                Animator = GetComponent<Animator>();
            }
        }

        void Update()
        {
            if (AutoSet && _rigidbody != null && _rigidbody.velocity.magnitude > 0)
            {
                SetAnimatorSpeed(_rigidbody.velocity);
            }
        }


        public void SetAnimatorSpeed(Vector3 moveDirection)
        {
            Animator.SetFloat(SpeedAnimatorVariableName, moveDirection.magnitude);
        }
    }
}