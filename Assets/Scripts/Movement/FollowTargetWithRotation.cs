using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class FollowTargetWithRotation : MonoBehaviour
    {
        public Transform Target;
        public float Speed;
        public int RotationOffset = 0;

        private bool _movingAfterTarget;

        private Rigidbody _rigidbodyToMove;

        void Start()
        {
            _rigidbodyToMove = GetComponent<Rigidbody>();
            StartMoving();
        }

        public void SetObjectToMove(Rigidbody rigidbodyToMove)
        {
            _rigidbodyToMove = rigidbodyToMove;
        }

        public void SetTarget(Transform target)
        {
            Target = target;
            StartMoving();
        }

        public void StopMoving()
        {
            _movingAfterTarget = false;
        }

        public void StartMoving()
        {
            _movingAfterTarget = true;
        }

        void Update()
        {
            transform.LookAt(Target);
            if (_movingAfterTarget && Target != null && _rigidbodyToMove != null)
            {
                Vector3 moveDirection = transform.forward * Speed;
                moveDirection.y = _rigidbodyToMove.velocity.y;
                _rigidbodyToMove.velocity = moveDirection;
            }
        }
    }
}